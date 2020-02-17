using OhmCalculator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator.Common
{
    public abstract class BandList
    {
        public BandList() { }
        public abstract Band findInlist(string bandColor);

        public abstract List<Dictionary<string, string>> asDictionaryList();

    }

    public class PrimaryBandList : BandList
    {

        public List<PrimaryBand> Collection
        { get; set; }
        public PrimaryBandList(List<PrimaryBand> lcolor)
        {
            Collection = lcolor;
        }
        public override Band findInlist(string bandColor)
        {
            //PrimaryBandColor a;
            PrimaryBandsColors ePmColor;

            if (!Enum.TryParse(bandColor, true, out ePmColor))
            {
                throw new ArgumentException("Invalid bandColor");
            }
            Band result = Collection.Find((x) => (x.Color as PrimaryBandColor).Name == ePmColor);
            if (result == null)
                throw new ColorNotFoundException("bandColor not found");
            return result;
        }

        public override List<Dictionary<string, string>> asDictionaryList()
        {
            var output = new List<Dictionary<string, string>>();
            if (Collection != null)
            {
                foreach (var item in Collection)
                {
                    output.Add(
                        new Dictionary<string, string>
                        {
                             { "Name", (item.Color as PrimaryBandColor).Name.ToString() },
                             { "Code", item.Color.Code },
                             { "Value", item.Value.ToString() },
                        });
                }


            }
            return output;
        }
    }

    public class MultBandList : BandList
    {
        public List<MultiplierBand> Collection
        { get; set; }

        public MultBandList(List<MultiplierBand> lcolor)
        {
            Collection = lcolor;
        }

        public override Band findInlist(string bandColor)
        {             
            //PrimaryBandColor a;
            MultiplierBandColors ePmColor;

            if (!Enum.TryParse(bandColor, true, out ePmColor))
            {
                throw new ArgumentException("Invalid bandColor");
            }
            Band result = Collection.Find((x) => (x.Color as MultiplierBandColor).Name == ePmColor);
            if (result == null)
                throw new ColorNotFoundException("bandColor not found");
            return result;
        }

        public override List<Dictionary<string, string>> asDictionaryList()
        {
            var output = new List<Dictionary<string, string>>();
            if (Collection != null)
            {
                foreach (var item in Collection)
                {
                    output.Add(
                        new Dictionary<string, string>
                        {
                             { "Name", (item.Color as MultiplierBandColor).Name.ToString() },
                             { "Code", item.Color.Code },
                             { "Value", item.Value.ToString() },
                        });
                }


            }
            return output;
        }
    }

    public class TolBandList : BandList
    {
        public List<ToleranceBand> Collection
        { get; set; }

        public TolBandList(List<ToleranceBand> lcolor)
        {
            Collection = lcolor;
        }
        public override Band findInlist(string bandColor)
        {
            //PrimaryBandColor a;
            ToleranceBandColors ePmColor;

            if (!Enum.TryParse(bandColor, true, out ePmColor))
            {
                throw new ArgumentException("Invalid bandColor");
            }
            Band result = Collection.Find((x) => (x.Color as ToleranceBandColor).Name == ePmColor);
            if (result == null)
                throw new ColorNotFoundException("bandColor not found");
            return result;            
        }

        public override List<Dictionary<string, string>> asDictionaryList()
        {
            var output = new List<Dictionary<string, string>>();
            if (Collection != null)
            {
                foreach (var item in Collection)
                {
                    output.Add(
                        new Dictionary<string, string>
                        {
                             { "Name", (item.Color as ToleranceBandColor).Name.ToString() },
                             { "Code", item.Color.Code },
                             { "Value", item.Value.ToString() },
                        });
                }
            }
            return output;
        }
    }
}
