using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator.Entities
{
    public abstract class Band
    {
        public BandColor Color
        { get; set; }
        public double Value
        { get; set; }
        public string Type
        { get; set; }
        //Operation

        protected Band() { }
        protected Band(BandColor col, double val)
        {
            Color = col;
            Value = val;
        }
    }
}
