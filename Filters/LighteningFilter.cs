using System;

namespace MyPhotoshop
{
	public class LighteningFilter : PixelFilter
	{
        public LighteningFilter () : base(new LighteningParameters()) { }
        public override string ToString ()
		{
			return "Осветление/затемнение";
		}

        protected override Pixel ProcessPixel(Pixel original, IParametrs parameters)
        {
            return original * (parameters as LighteningParameters).Coefficient;
        }
    }
}

