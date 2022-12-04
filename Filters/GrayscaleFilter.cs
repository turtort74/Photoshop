using System;

namespace MyPhotoshop
{
	public class GrayscaleFilter : PixelFilter
	{
        public  GrayscaleFilter() : base(new EmptyParameters()) { }
		
		public override string ToString ()
		{
			return "Черно-белое";
		}

        protected override Pixel ProcessPixel(Pixel original, IParametrs parameters)
        {
            var average = (original.R + original.G + original.B) / 3;
            return new Pixel(average, average, average);
        }

    }
}

