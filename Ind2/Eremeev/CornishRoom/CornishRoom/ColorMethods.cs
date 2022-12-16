using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CornishRoom
{
    public static class ColorMethods
    {
        public static Color Multiply(Color lhs, double rhs)
        {
            int r = ToColorComponent(lhs.R * rhs);
            int g = ToColorComponent(lhs.G * rhs);
            int b = ToColorComponent(lhs.B * rhs);
            return Color.FromArgb(r, g, b);
        }

        private static int ToColorComponent(double value)
            => Math.Max(Math.Min((int)Math.Round(value), 255), 0);

        public static Color Add(Color lhs, Color rhs)
        {
            int r = AddColorComponents(lhs.R, rhs.R);
            int g = AddColorComponents(lhs.G, rhs.G);
            int b = AddColorComponents(lhs.B, rhs.B);
            return Color.FromArgb(r, g, b);
        }

        private static int AddColorComponents(int lhs, int rhs) 
            => Math.Min(lhs + rhs, 255);
    }
}
