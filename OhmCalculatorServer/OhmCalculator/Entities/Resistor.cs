using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OhmCalculator.Interfaces;

namespace OhmCalculator.Entities
{
    class Resistor
    {
        private PrimaryBand pband1;
        private PrimaryBand pband2;
        private MultiplierBand mBand;
        private ToleranceBand tband;

        public Resistor(PrimaryBand pb1, PrimaryBand pb2, MultiplierBand mb, ToleranceBand tb)
        {
            pband1 = pb1;
            pband2 = pb2;
            mBand = mb;
            tband = tb;
        }

        public double getValue()
        {
            double result = Convert.ToDouble(pband1.Value.ToString() + pband2.Value.ToString()) * mBand.Value;
            return result;
        }
    }
}
