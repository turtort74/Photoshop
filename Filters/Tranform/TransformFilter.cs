using System;
using System.Drawing;
using System.Security.Cryptography;

namespace MyPhotoshop
{
    public class TransformFilter : TransformFilter<EmptyParameters>
    {
        private string name;
        public TransformFilter(string name, Func<Size, Size> sizeTransformer, Func<Point, Size, Point> pointTransformer) 
        : base(name, new FreeTransformer(sizeTransformer, pointTransformer)) { }
    }
}