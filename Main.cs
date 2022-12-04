using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace MyPhotoshop
{
	class MainClass
	{
        [STAThread]
		public static void Main (string[] args)
		{
			var window=new MainWindow();
			window.AddFilter (new PixelFilter<LighteningParameters>(
                "����������/����������",
                (original, parameters) => original * parameters.Coefficient));

			window.AddFilter(new PixelFilter<EmptyParameters>(
			"�����-�����",
            (original, parameters) =>
                {
                    var average = (original.R + original.G + original.B) / 3;
                    return new Pixel(average, average, average);
                }));

            window.AddFilter(new TransformFilter(
                "�������� �� �����������",
                size => size,
                (point, size) => new Point(size.Width - point.X - 1, point.Y)
            ));

            window.AddFilter(new TransformFilter(
                "������� ������ ������� �������",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(point.Y, point.X)
                     ));

            window.AddFilter(new TransformFilter(
                "������� �� ������� �������",
                size => new Size(size.Height, size.Width),
                (point, size) => new Point(size.Width - point.Y - 1, size.Height - point.X - 1)
            ));

            window.AddFilter(new TransformFilter<RotationParameters>(
                "��������� ��������", new RotationTransformer()));
            Application.Run (window);
		}
	}
}
