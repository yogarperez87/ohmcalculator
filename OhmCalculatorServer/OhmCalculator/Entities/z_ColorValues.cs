using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator.Entities
{
    abstract class ColorValues
    {
        protected Dictionary<string, double> values;

        public ColorValues()
        { }

        public Dictionary<string, double> Values { get => values; }

        protected abstract Dictionary<string, double> initializeVal();
    }

    

    class PBColorValues: ColorValues
    {
        public PBColorValues():base()
        {
            base.values = initializeVal();
        }

        protected override Dictionary<string, double> initializeVal() 
        {
            Dictionary<string, double> output = new Dictionary<string, double>();
            int val = 0;
            foreach (string n in Enum.GetNames(typeof(PrimaryBandsColors)))
            {
                output.Add(n, val);
                val++;
            }
            return output;
        }
    }

    class MBColorsValues : ColorValues
    {
        public MBColorsValues() : base()
        {
            base.values = initializeVal();
        }

        protected override Dictionary<string, double> initializeVal()
        {
            Dictionary<string, double> output = new Dictionary<string, double>();
            double val = 1;
            int counter = 0;
            foreach (string n in Enum.GetNames(typeof(MultiplierBandColors)))
            {
                output.Add(n, val);
                
                if(counter < 9)
                {
                    val *= 10;
                }
                else if(counter == 9)
                {
                    val = 1 / 10.0;
                }
                else
                {
                    val /= 10.0;
                }
                counter++;
            }
            return output;
        }
    }
}
