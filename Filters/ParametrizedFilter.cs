namespace MyPhotoshop
{
    public abstract class ParametrizedFilter : IFilter
    {
        public IParametrs parametrs;
        public ParametrizedFilter(IParametrs parametrs)
        {
            this.parametrs = parametrs;
        }

        public ParameterInfo[] GetParameters()
        {
            return parametrs.GetDescription();
        }

        public Photo Process(Photo original, double[] values)
        {
            this.parametrs.Parse(values);
            return Process(original, parametrs);
        }

        public abstract Photo Process(Photo original, IParametrs parametrs);
    }
}