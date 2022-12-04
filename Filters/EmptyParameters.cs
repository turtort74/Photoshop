namespace MyPhotoshop
{
    public class EmptyParameters : IParametrs
    {
        public ParameterInfo[] GetDescription()
        {
            return new ParameterInfo[0];
        }

        public void Parse(double[] parameters) { }
    }
}