using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotoshop
{
    abstract public class PixelFilter : ParametrizedFilter
    {
        public PixelFilter (IParametrs parameters) : base(parameters) { }
        public override Photo Process(Photo original, IParametrs values)
        {
            var result = new Photo(original.width, original.height);
            for (int x = 0; x < result.width; x++)
            {
                for (int y = 0; y < result.height; y++)
                {
                    result[x, y] = ProcessPixel(original[x, y], values);
                }
            }
            return result;
        }

        protected abstract Pixel ProcessPixel(Pixel original, IParametrs parameters);
    }
}
