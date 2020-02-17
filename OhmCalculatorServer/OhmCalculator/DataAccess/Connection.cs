using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using OhmCalculator.Entities;
using OhmCalculator.Common;

namespace OhmCalculator.DataAccess
{
    class Connection
    {
        private string fullPath;

        public Connection(string path, string fileName) {
            fullPath = $@"{path}/{fileName}";
        }

        //public List<T> GetBandColors<T>()
        //{
        //    XElement root = XElement.Load(fullPath);
        //    var ColorsData =
        //    root.Elements("Color").Where
        //    (el => (string)el.Attribute("Type") == "p")
        //    .Select(el => new PrimaryBandColor
        //    {
        //        Code = el.Element("Code").Value,
        //        Name = el.Element("Name").Value,
        //        Value = Convert.ToDouble(el.Element("Value").Value)
        //    });

        //    return Utils.ToList(ColorsData);
        //}


        public List<PrimaryBand> GetPrimaryBandColors()
        {
            XElement root = XElement.Load(fullPath);
            var ColorsData =
            root.Elements("Color").Where
            (el => (string)el.Attribute("Type") == "p")
            .Select(el => {
                PrimaryBandsColors eColorName;
                if(Enum.TryParse(el.Element("Name").Value, true, out eColorName))
                {
                    return new PrimaryBand
                    {
                        Color = new PrimaryBandColor
                        {
                            Name = eColorName,
                            Code = el.Element("Code").Value
                        },
                        Value = Convert.ToDouble(el.Element("Value").Value)
                    };
                }
                return null;
            });
            return Utils.ToList(ColorsData);          
        }

        public List<MultiplierBand> GetMultBandColors()
        {
            XElement root = XElement.Load(fullPath);
            var ColorsData =
            root.Elements("Color").Where
            (el => (string)el.Attribute("Type") == "m")
            .Select(el => {
                MultiplierBandColors eColorName;
                if (Enum.TryParse(el.Element("Name").Value, true, out eColorName))
                {
                    return new MultiplierBand
                    {
                        Color = new MultiplierBandColor 
                        {
                            Code = el.Element("Code").Value,
                            Name = eColorName
                        },                        
                        Value = Convert.ToDouble(el.Element("Value").Value)
                    };
                }
                return null;
            }
            );
            return Utils.ToList(ColorsData);
        }

        public List<ToleranceBand> GetTolBandColors()
        {
            XElement root = XElement.Load(fullPath);
            var ColorsData =
            root.Elements("Color").Where
            (el => (string)el.Attribute("Type") == "t")
            .Select(el => {
                ToleranceBandColors eColorName;
                if (Enum.TryParse(el.Element("Name").Value, true, out eColorName))
                {
                    return new ToleranceBand
                    {
                        Color = new ToleranceBandColor
                        {
                            Code = el.Element("Code").Value,
                            Name = eColorName
                        },                        
                        Value = Convert.ToDouble(el.Element("Value").Value)
                    };
                }
                return null;
            }
            );
            return Utils.ToList(ColorsData);
        }

        //public double getColorValue(string color, string type) 
        //{
        //    XElement root = XElement.Load(fullPath);

        //    var ColorsData = root.Elements("Color").Where
        //    (el => (string)el.Attribute("Type") == type)
        //    .Where(el => (string)el.Element("Name") == color)
        //    .Select(el => el.Element("Value").Value
        //    );
        //    return Convert.ToDouble(ColorsData.FirstOrDefault());
        //}
    }
}
