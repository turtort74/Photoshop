namespace MyPhotoshop
{
    abstract public class PixelFilter<TParameters> : ParametrizedFilter<TParameters>
        where TParameters : IParametrs, new ()
    {
        public override Photo Process(Photo original, TParameters values)
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

        protected abstract Pixel ProcessPixel(Pixel original, TParameters parameters);
    }
}
