using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OhmCalculator.Interfaces;
using OhmCalculator.Entities;
using OhmCalculator.DataAccess;
using OhmCalculator.Common;

namespace OhmCalculator.Entities
{
    public class OhmValueCalculator: IOhmCalcOperations
    {
        Connection conn;

        PrimaryBandList primBandColorList;

        MultBandList multBandColorList;

        TolBandList tolBandColorList;

        public OhmValueCalculator()
        {
            conn = new Connection("Data", "ColorsData.xml");
            primBandColorList = new PrimaryBandList(conn.GetPrimaryBandColors());
            multBandColorList = new MultBandList(conn.GetMultBandColors());
            tolBandColorList = new TolBandList(conn.GetTolBandColors());
        }
        public int CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor) 
        {
            PrimaryBand bandA = (PrimaryBand)primBandColorList.findInlist(bandAColor);
            PrimaryBand bandB = (PrimaryBand)primBandColorList.findInlist(bandBColor);
            MultiplierBand bandC = (MultiplierBand)multBandColorList.findInlist(bandCColor);
            ToleranceBand bandD = (ToleranceBand)tolBandColorList.findInlist(bandDColor);

            var resistor = new Resistor(bandA, bandB, bandC, bandD);
            double resistorValue = resistor.getValue();
            if (resistorValue > int.MaxValue)
                return int.MaxValue;
            return Convert.ToInt32(resistor.getValue());
        }

        public PrimaryBandList GetPrimaryBands() 
        {
            return primBandColorList;
        }

        public MultBandList GetMultBands() 
        {
            return multBandColorList;
        }

        public TolBandList GeTolBands()
        {
            return tolBandColorList;
        }
    }
}
