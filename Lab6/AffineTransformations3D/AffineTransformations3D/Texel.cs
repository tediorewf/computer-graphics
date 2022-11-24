using System.Drawing;

namespace AffineTransformations3D
{
    public class Texel
    {
        public int X { get; }
        public int Y { get; }
        public Color Color { get; }

        public Texel(int x, int y, Color color)
        {
            X = x;
            Y = y;
            Color = color;
        }
    }
}
