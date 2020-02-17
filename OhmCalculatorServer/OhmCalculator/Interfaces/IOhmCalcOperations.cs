using OhmCalculator.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator.Interfaces
{
    public interface IOhmCalcOperations:IOhmValueCalculator
    {
        PrimaryBandList GetPrimaryBands();

        MultBandList GetMultBands();

        TolBandList GeTolBands();
    }
}
