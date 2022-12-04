namespace MyPhotoshop
{
    public interface IParametrs
    {
        ParameterInfo[] GetDescription();
        void Parse(double[] parameters);
    }
}
