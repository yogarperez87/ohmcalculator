using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator.Entities
{
    public class ToleranceBand:Band
    {
        public ToleranceBand()
        {
            base.Type = "t";
        }
        public ToleranceBand(ToleranceBandColor col, double value) : base(col, value)
        {
            base.Type = "t";
        }
    }
}
