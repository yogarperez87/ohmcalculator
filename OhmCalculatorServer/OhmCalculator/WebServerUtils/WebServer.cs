using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using OhmCalculator.Interfaces;


namespace OhmCalculator.WebServerUtils
{
    public class WebServer
    {
        private readonly HttpListener _listener = new HttpListener();
        private int _RunningRequests;
        private IOhmCalcOperations ohmValueCalc;

        public WebServer(string[] prefixes, IOhmCalcOperations ohmCalc)
        {
            if (!HttpListener.IsSupported)
                throw new NotSupportedException(
                    "Needs Windows XP SP2, Server 2003 or later.");

            // URI prefixes are required, for example 
            // "http://localhost:4602/index/".
            if (prefixes == null || prefixes.Length == 0)
                throw new ArgumentException("prefixes");

            foreach (string s in prefixes)
                _listener.Prefixes.Add(s);

            ohmValueCalc = ohmCalc;
        }

        public void Run()
        {
            try
            {
                _listener.Start();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ThreadPool.QueueUserWorkItem((o) =>
            {                
                try
                {
                    while (_listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem((c) =>
                        {
                            Interlocked.Increment(ref _RunningRequests);
                            var ctx = c as HttpListenerContext;
                            try
                            {
                                _handler(ctx.Request, ctx.Response);
                            }
                            catch (Exception ex)
                            {
                                ctx.Response.StatusCode = 500;                                
                            }
                            finally
                            {
                                try
                                {
                                    ctx.Response.OutputStream.Close();
                                }
                                catch
                                {
                                }
                                Interlocked.Decrement(ref _RunningRequests);
                            }
                        }, _listener.GetContext());
                    }
                    
                }
                catch (Exception ex)
                {
                    
                    throw ex;
                } // suppress any exceptions
                finally
                {
                    _listener.Stop();
                    _listener.Close();
                }
            });
        }

        private void _handler(HttpListenerRequest request, HttpListenerResponse response)
        {
            try
            {
                string post = String.Empty;
                Dictionary<string, string> reqParams = null;
                if (request.HttpMethod == "POST")
                {
                    using (System.IO.StreamReader reader = new StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        post = reader.ReadToEnd();
                    }
                    reqParams = handlePostParams(post);
                }
                else if(request.HttpMethod == "GET")
                {
                    reqParams = handleGetParams(request.QueryString);
                }

                string rstr = handleRequest(request, reqParams);
                byte[] buf = Encoding.UTF8.GetBytes(rstr);
                response.ContentLength64 = buf.Length;
                response.ContentType = "text/plain";
                response.AddHeader("Access-Control-Allow-Origin", "*");
                //response.ContentType = "text/plain";
                //response.AddHeader("Access-Control-Allow-Origin", "*");
                //response.AddHeader("Access-Control-Allow-Methods", "GET, POST, PUT, DELETE, OPTIONS");
                //response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Content-Range, Content-Disposition, Content-Description, Access-Control-Allow-Origin");
                response.OutputStream.Write(buf, 0, buf.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private Dictionary<string, string> handleGetParams(System.Collections.Specialized.NameValueCollection getPar)
        {
            var output = new Dictionary<string, string>();
            foreach (var k in getPar.AllKeys)
            {
                output.Add(k, getPar[k]);
            }            
            return output;
        }
        private Dictionary<string, string> handlePostParams(string postPar)
        {
            var reqPar = new Dictionary<string, string>();
            try
            {
                var a = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(postPar);
                reqPar = a;
            }
            catch (IndexOutOfRangeException ex)
            {
                //BfgLog.WriteLine(ex.Message, "ERROR", "BFGDM.WS.handlePostParams.99");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return reqPar;
        }

        public string handleRequest(HttpListenerRequest request, Dictionary<string, string> postParams)
        {
            string outPut = String.Empty;
            var jserializer = new JavaScriptSerializer();

            try
            {
                string fullPath = getPath(request);
                
                string[] path = fullPath.Split('/');
                if (path.Length != 3)
                {
                    Response resp = new Response();
                    resp.Rc = "404";
                    resp.Msg = "Not Found";
                    outPut = jserializer.Serialize(resp);
                }

                switch (path[path.Length-1])
                {
                    case "getpbands":
                        var pColorResult = ohmValueCalc.GetPrimaryBands().asDictionaryList();
                        Response pColoResp = new ColorListResponse()
                        {
                            Bands = pColorResult
                        };                       
                        outPut = jserializer.Serialize(pColoResp);

                        break;
                    case "getmbands":
                        var mColorResult = ohmValueCalc.GetMultBands().asDictionaryList();
                        Response mColoResp = new ColorListResponse()
                        {
                            Bands = mColorResult
                        };
                        outPut = jserializer.Serialize(mColoResp);

                        break;
                    case "gettolbands":
                        var tColorResult = ohmValueCalc.GeTolBands().asDictionaryList();
                        Response tColoResp = new ColorListResponse()
                        {
                            Bands = tColorResult
                        };
                        outPut = jserializer.Serialize(tColoResp);

                        break;
                    case "calcohmvalue":
                        string bandAColorName = "bandAColor";
                        string bandBColorName = "bandBColor";
                        string bandCColorName = "bandCColor";
                        string bandDColorName = "bandDColor";
                        if(validateParams(new List<string> { bandAColorName, bandBColorName, bandCColorName, bandDColorName }, postParams))
                        {
                            string bandAColor = null;
                            string bandBColor = null;
                            string bandCColor = null;
                            string bandDColor = null;
                            postParams.TryGetValue(bandAColorName, out bandAColor);
                            postParams.TryGetValue(bandBColorName, out bandBColor);
                            postParams.TryGetValue(bandCColorName, out bandCColor);
                            postParams.TryGetValue(bandDColorName, out bandDColor);
                            try
                            {
                                Response calOhmResp = new CalcOhmResponse()
                                {
                                    Value = ohmValueCalc.CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor)
                                };
                                outPut = jserializer.Serialize(calOhmResp);
                            }
                            catch (ArgumentException ex)
                            {
                                Response calcErrResp = new Response();
                                calcErrResp.Rc = "422";
                                calcErrResp.Msg = ex.Message;
                                outPut = jserializer.Serialize(calcErrResp);
                            }
                           
                        }
                        else
                        {
                            Response calcErrResp = new Response();
                            calcErrResp.Rc = "422";
                            calcErrResp.Msg = "Missing Parameters";
                            outPut = jserializer.Serialize(calcErrResp);
                        }
                       

                        break;


                    default:
                        Response resp = new Response();
                        resp.Rc = "404";
                        resp.Msg = "Not Found";
                        outPut = jserializer.Serialize(resp);
                        break;
                }
            }
            catch (Exception ex)
            {
                Response resp = new Response();
                resp.Rc = "500";
                resp.Msg = ex.Message;
                outPut = jserializer.Serialize(resp);
            }
            return outPut;
        }

        private string getPath(HttpListenerRequest request)
        {
            //string a = request.Url.AbsoluteUri;
            //string b = request.Url.OriginalString;
            //string c = request.Url.AbsolutePath;
            //string d = request.Url.Scheme;
            //string e = request.Url.Fragment;
            //string f = request.Url.Host;
            //string g = request.Url.LocalPath;
            //string[] h = request.Url.Segments;
            //string fullPath = String.Empty;
            //if (request.RawUrl.IndexOf("?") >= 0)
            //{
            //    fullPath = request.RawUrl.Substring(0, request.RawUrl.IndexOf("?"));
            //}
            //else
            //{
            //    fullPath = request.RawUrl;
            //}

            return request.Url.AbsolutePath;
        }

        static bool validateParams(List<string> _params, Dictionary<string, string> values)
        {
            try
            {
                foreach (var item in _params)
                {
                    string temp;
                    if (!values.TryGetValue(item, out temp))
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
    }
}
