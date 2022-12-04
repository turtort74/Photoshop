using System;

namespace MyPhotoshop
{
    public class RotationParameters : IParametrs
    {
        [ParameterInfo(Name = "Угол", MaxValue = 360, MinValue = 0, Increment = 15, DefaultValue = 0)]
        public double Angle { get; set; }
    }
}