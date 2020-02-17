using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OhmCalculator.Common
{
  
    //abstract class BColor
    //{        
    //    protected abstract double Brown { get; }
    //    protected abstract double Red { get; }
    //    protected abstract double Green { get; }
    //    protected abstract double Blue { get; }
    //    protected abstract double Violet { get; }
    //    protected abstract double Grey { get; }
      
    //}

    //abstract class CColor: BColor
    //{
    //    protected abstract double Black { get; }
    //    protected abstract double Orange { get; }
    //    protected abstract double Yellow { get; }
    //    protected abstract double White { get; }
    //}


    //class PrimaryBandsColors1 : CColor
    //{
    //    protected override double Black { get => 0; }
    //    protected override double Brown { get=> 1; }
    //    protected override double Red { get => 2; }
    //    protected override double Orange { get => 3; }
    //    protected override double Yellow { get => 4; }
    //    protected override double Green { get => 5; }
    //    protected override double Blue { get => 6; }
    //    protected override double Violet { get => 7; }
    //    protected override double Grey { get => 8; }
    //    protected override double White { get => 9; }

    //}

    //class MultiplierBandsColors : CColor
    //{
    //    protected override double Black { get => 1; }
    //    protected override double Brown { get => Black * 10; }
    //    protected override double Red { get => Brown * 10; }
    //    protected override double Orange { get => Red * 10; }
    //    protected override double Yellow { get => Orange * 10; }
    //    protected override double Green { get => Yellow * 10; }
    //    protected override double Blue { get => Green * 10; }
    //    protected override double Violet { get => Blue * 10; }
    //    protected override double Grey { get => Violet * 10; }
    //    protected override double White { get => Grey * 10; }
    //    protected double Gold { get => 0.1; }
    //    protected double Silver { get => 0.01; }

    //}

    //class ToleranceBandsColors : BColor
    //{       
    //    protected override double Brown { get => 1; }
    //    protected override double Red { get => 2; }        
    //    protected override double Green { get => 0.5; }
    //    protected override double Blue { get => 0.25; }
    //    protected override double Violet { get => 0.1; }
    //    protected override double Grey { get => 0.05; }
    //    protected double Gold { get => 0.5; }
    //    protected double Silver { get => 0.10; }
    //}

    ////class PrimaryBandsColors : BColor
    ////{
    ////    protected override void initializeColors()
    ////    {
    ////        new Dictionary<string, int>()
    ////        {
    ////             { "Black", 0 },
    ////             { "Brown", 1 },
    ////             { "Red", 2 },
    ////             { "Orange", 3 },
    ////             { "Yellow", 4 },
    ////             { "Green", 5 },
    ////             { "Blue", 6 },
    ////             { "Violet", 7 },
    ////             { "Grey", 8 },
    ////             { "White", 9 },
    ////        };
    ////    }
    ////}
    //enum PrimaryBandsColors111
    //{
    //    Black = 0,
    //    Brown = 1,
    //    Red = 2,
    //    Orange = 3,
    //    Yellow = 4,
    //    Green = 5,
    //    Blue = 6,
    //    Violet = 7,
    //    Grey = 8,
    //    White = 9
    //}


    //struct MultiplierBandColors
    //{
    //    private const double Black = 1;
    //    private const double Brown = Black * 10;
    //    private const double Red = Brown * 10;
    //    private const double Orange = Red * 10;
    //    private const double Yellow = Orange * 10;
    //    private const double Green = Yellow * 10;
    //    private const double Blue = Green * 10;
    //    private const double Violet = Blue * 10;
    //    private const double Grey = Violet * 10;
    //    private const double White = Grey * 10;
    //    private const double Gold = Black * 0.1;
    //    private const double Silver = Black * 0.01;

    //}



    ////enum MultiplierBandColors
    ////{
    ////    Black = 1,
    ////    Brown = MultiplierBandColors.Black * 10,
    ////    Red = MultiplierBandColors.Brown * 10,
    ////    Orange = MultiplierBandColors.Red * 10,
    ////    Yellow = MultiplierBandColors.Orange * 10,
    ////    Green = MultiplierBandColors.Yellow * 10,
    ////    Blue = MultiplierBandColors.Green * 10,
    ////    Violet = MultiplierBandColors.Blue * 10,
    ////    Grey = MultiplierBandColors.Violet * 10,
    ////    White = MultiplierBandColors.Grey * 10,

    ////    Gold = MultiplierBandColors.Black * 0.1
    ////}
    ////enum MultiplierBandColors
    ////{
    ////    Black = 1,
    ////    Brown = 10,
    ////    Red = 100,
    ////    Orange = 1000,
    ////    Yellow = 10000,
    ////    Green = MultiplierBandColors.Yellow * 10,
    ////    Blue = 6,
    ////    Violet = 7,
    ////    Grey = 8,
    ////    White = 9
    ////}

    //abstract class PrimaryBand
    //{
    //    protected abstract Color Brown { get; }
    //}

    //class Color
    //{
    //    private string name;
    //    private string code;
    //    private double value;

    //    public Color(string nam, string cod, double val)
    //    {
    //        name = nam;
    //        code = cod;
    //        value = val;
    //    }
    //}
}
