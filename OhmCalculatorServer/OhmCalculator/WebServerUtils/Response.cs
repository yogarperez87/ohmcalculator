using OhmCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator.WebServerUtils
{
    class Response
    {
        public string Rc { get; set; }
        public string Msg { get; set; }      
        
        public Response()
        {
            Rc = "200";
            Msg = "Success";
        }
    }
    class ColorListResponse : Response
    {
        public List<Dictionary<string, string>> Bands
        { get; set; }
    }

    class PrimColorListResponse: Response
    {
        public List<PrimaryBandColor> BandColors
        { get; set; }
    }

    class MultColorListResponse : Response
    {
        public List<MultiplierBandColor> BandColors
        { get; set; }
    }

    class TolColorListResponse : Response
    {
        public List<ToleranceBandColor> BandColors
        { get; set; }
    }

    class CalcOhmResponse : Response
    {
        public int Value
        { get; set; }
    }
}
