using System.Drawing;

namespace AffineTransformations3D
{
    public class Texture
    {
        private Texel[,] pixels;

        public Texture(int width, int height)
        {
            pixels = new Texel[height, width];
        }

        public static Texture FromBitmap(Bitmap bitmap)
        {
            var texture = new Texture(bitmap.Width, bitmap.Height);
            texture.Fill(bitmap);
            return texture;
        }

        public Texel this[int x, int y] => pixels[x, y];

        public void Fill(Bitmap image)
        {
            for (int x = 0; x < image.Height; x += 1)
            {
                for (int y = 0; y < image.Width; y += 1)
                {
                    var color = image.GetPixel(x, y);
                    var vertexTexture = new Texel(x, y, color);
                    pixels[x, y] = vertexTexture;
                }
            }
        }
    }
}
