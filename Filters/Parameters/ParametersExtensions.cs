using System.Linq;

namespace MyPhotoshop
{
    public static class ParametersExtensions
    {
        public static ParameterInfo[] GetDescription(this IParametrs parameters)
        {
            return parameters.GetType()
                .GetProperties()
                .Select(z => z.GetCustomAttributes(typeof(ParameterInfo), false))
                .Where(z => z.Length > 0)
                .Select(z => z[0])
                .Cast<ParameterInfo>()
                .ToArray();
        }

        public static void Parse(this IParametrs parameters, double[] value)
        {
            var properties = parameters
                .GetType()
                .GetProperties()
                .Where(z => z.GetCustomAttributes(typeof(ParameterInfo), false).Length > 0)
                .ToArray();
            for (int i = 0; i < value.Length; i++)
            {
                properties[i].SetValue(parameters, value[i], new object[0]);
            }
        }
    }
}