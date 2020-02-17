using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator.Entities
{
    public class MultiplierBand:Band
    {
        public MultiplierBand() 
        {
            base.Type = "m";
        }
        public MultiplierBand(MultiplierBandColor col, double value) : base(col, value)
        {
            base.Type = "m";
        }
    }
}
