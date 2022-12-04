using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MyPhotoshop
{
    public struct Pixel
    {
        double r;
        double g;
        double b;

        public Pixel(double r, double g, double b)
        {
            this.r = this.g = this.b = 0;
            R = r;
            G = g;
            B = b;
        }
        public double Chek(double value)
        {
            if (value < 0 || value > 1)
                throw new ArgumentOutOfRangeException("value");
            return value;
        }
        public double R
        {
            get { return r;}
            set { r = Chek(value); }
        }

        public double G
        {
            get { return g;}
            set { g = Chek(value); }
        }

        public double B
        {
            get { return b; }
            set { b = Chek(value); }
        }

        public static Pixel operator *(Pixel p, double c)
        {
            return new Pixel(Trim(p.R * c), Trim(p.G * c), Trim(p.B * c));
        }

        public static Pixel operator *(double c, Pixel p)
        {
            return p * c;
        }
        public static double Trim(double value) => (value < 0) ? 0 : (value > 1) ? 1 : value;
    }
}
