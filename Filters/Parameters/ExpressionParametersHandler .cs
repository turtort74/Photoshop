using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography;

namespace MyPhotoshop
{
    public class ExpressionParametersHandler<TParameters> : IParametersHandler<TParameters>
        where TParameters : IParametrs, new()
    {
        private static Func<double[], TParameters> parser;
        private static ParameterInfo[] description;
        static ExpressionParametersHandler()
        {
            var properties = typeof(TParameters)
                .GetProperties()
                .Where(z => z.GetCustomAttributes(typeof(ParameterInfo), false).Length > 0)
                .ToArray();
            description = typeof(TParameters)
                .GetProperties()
                .Select(z => z.GetCustomAttributes(typeof(ParameterInfo), false))
                .Where(z => z.Length > 0)
                .Select(z => z[0])
                .Cast<ParameterInfo>()
                .ToArray();

            var arg = Expression.Parameter(typeof(double[]), "value");
            var bindings = new List<MemberBinding>();
            for (int i = 0; i < properties.Length; i++)
            {
                var binding = Expression.Bind(
                    properties[i],
                    Expression.ArrayIndex(
                        arg,
                        Expression.Constant(i)));
                bindings.Add(binding);
            }

            var body = Expression.MemberInit(
                Expression.New(typeof(TParameters).GetConstructor(new Type[0])),
                bindings);
            var lambda = Expression.Lambda<Func<double[], TParameters>>(
                body,
                arg);
            parser = lambda.Compile();
        }

        public TParameters CreateParameters(double[] value)
        {
            return parser(value);
        }

        public ParameterInfo[] GetDescription()
        {
            return description;
        }
    }
}