using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator.Entities
{
    public class PrimaryBand : Band
    {
        //public PrimaryBand()
        //{
        //}


        public PrimaryBand() {
           base.Type = "p";
        }
        public PrimaryBand(PrimaryBandColor col, double value):base(col, value)
        {
            base.Type = "p";
        }       
    }
}
