using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace MyPhotoshop
{
    public class StaticParametersHandler<TParameters> : IParametersHandler<TParameters>
        where TParameters : IParametrs, new()
    {
        private static PropertyInfo[] properties;
        private static ParameterInfo[] description;
        static StaticParametersHandler()
        {
            properties = typeof(TParameters)
                .GetProperties()
                .Where(z => z.GetCustomAttributes(typeof(ParameterInfo), false).Length > 0)
                .ToArray();
            description = properties
                .Select(z => z.GetCustomAttributes(typeof(ParameterInfo), false))
                .Select(z => z[0])
                .Cast<ParameterInfo>()
                .ToArray();
        }
        public TParameters CreateParameters(double[] value)
        {
            var parameters = new TParameters();
            for (int i = 0; i < value.Length; i++)
                properties[i].SetValue(parameters, value[i], new object[0]);
            return parameters;
        }

        public ParameterInfo[] GetDescription()
        {
            return description;
        }
    }
}