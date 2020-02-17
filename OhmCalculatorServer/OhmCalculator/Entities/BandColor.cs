using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator.Entities
{
    public enum PrimaryBandsColors
    {
        Black,
        Brown,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Violet,
        Grey,
        White
    }

    public enum MultiplierBandColors
    {
        Black,
        Brown,
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Violet,
        Grey,
        White,
        Gold,
        Silver
    }

    public enum ToleranceBandColors
    {
        Brown,
        Red,
        Green,
        Blue,
        Violet,
        Grey,
        Gold,
        Silver
    }

    public abstract class BandColor
    {
        public string Code
        { get; set; }      
        
        public BandColor()
        {
        }
        public BandColor(string code)
        {
            Code = code;
        }       
    }

    public class PrimaryBandColor : BandColor
    {
        public PrimaryBandsColors Name
        { get; set; }
        public PrimaryBandColor() { }
        public PrimaryBandColor(string code, double value) : base(code)
        {

        }
    }

    public class MultiplierBandColor : BandColor
    {
        public MultiplierBandColors Name
        { get; set; }
        public MultiplierBandColor() { }
        public MultiplierBandColor(string code, double value, MultiplierBandColors name) : base(code)
        {
            Name = name;
        }
    }

    public class ToleranceBandColor : BandColor
    {
        public ToleranceBandColors Name
        { get; set; }
        public ToleranceBandColor() { }
        public ToleranceBandColor(string code, double value, ToleranceBandColors name) : base(code)
        {
            Name = name;
        }
    }
}
