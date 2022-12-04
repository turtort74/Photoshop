using System;

namespace MyPhotoshop
{
    public class PixelFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParametrs, new()
    {
        private string name;
        private Func<Pixel, TParameters, Pixel> processor;
        public PixelFilter(string name, Func<Pixel, TParameters, Pixel> processor)
        {
            this.name = name;
            this.processor = processor;
        }

        public override Photo Process(Photo original, TParameters values)
        {
            var result = new Photo(original.width, original.height);
            for (int x = 0; x < result.width; x++)
            {
                for (int y = 0; y < result.height; y++)
                {
                    result[x, y] = processor(original[x, y], values);
                }
            }
            return result;
        }

        public override string ToString()
        {
            return name;
        }
    }
}
