using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using OhmCalculator.Common;
using OhmCalculator.Entities;
using OhmCalculator.DataAccess;
using OhmCalculator.WebServerUtils;

namespace OhmCalculator
{
    public partial class Form1 : Form
    {
        WebServer ws;
        public Form1()
        {
            InitializeComponent();
            ColorValues a = new MBColorsValues();
            string name = "Grey";
            PrimaryBandsColors color;
            var aaaa = Enum.TryParse("aa", true, out color);

            //XElement root = XElement.Load(@"Data/ColorsData.xml");
            //IEnumerable<XElement> address =
            //from el in root.Elements("Color")
            //where (string)el.Attribute("Type") == "p"
            //select el;

            Connection conn = new Connection("Data", "ColorsData.xml");
            List<PrimaryBand> aa = conn.GetPrimaryBandColors();

            List<MultiplierBand> bb = conn.GetMultBandColors();

            List<ToleranceBand> cc = conn.GetTolBandColors();

            OhmValueCalculator oCalc = new OhmValueCalculator();
            //calc.CalculateOhmValue("Red", "Black", "Black", "White");

            string[] prefixes = { "http://127.0.0.1:3003/oc/" };
            try
            {
                ws = new WebServer(prefixes, oCalc);
                ws.Run();
            }
            catch (Exception ex)
            {
                throw ex;
            }


            //label1.Text = PrimaryBandsColors.Blue.ToString();
        }
    }
}
