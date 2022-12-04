using System;

namespace MyPhotoshop
{
    public class RotationParameters : IParametrs
    {
        public double Angle { get; set; }
        public ParameterInfo[] GetDescription()
        {
            return new[]
            {
                new ParameterInfo { Name="Угол", MaxValue=360, MinValue=0, Increment=15, DefaultValue=0 }
            };
        }

        public void Parse(double[] parameters)
        {
            Angle = parameters[0];
        }
    }
}