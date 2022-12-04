using System.Drawing;

namespace MyPhotoshop
{
    public interface ITransformer<TParametrs>
        where TParametrs : IParametrs, new()
    {
        void Prepare(Size size, TParametrs parameters);
        Size ResultSize { get;  }
        Point? MapPoint(Point point);
    }
}