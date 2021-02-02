using System.Drawing;

namespace NUMC.Design.Resources
{
    public class Render
    {
        public static Bitmap Reversal(Bitmap bitmap)
        {
            Bitmap after = new Bitmap(bitmap.Width, bitmap.Height);

            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    ReversalColor(ref color);
                    after.SetPixel(x, y, color);
                }

            return after;
        }

        public static void ReversalColor(ref Color color)
        {
            color = Color.FromArgb
            (
                color.A,
                255 - color.R,
                255 - color.G,
                255 - color.B
            );
        }

        public static Color Average(Bitmap bitmap)
        {
            long a = 0, r = 0, g = 0, b = 0;
            long f = bitmap.Width * bitmap.Height;
            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    a += color.A;
                    r += color.R;
                    g += color.G;
                    b += color.B;
                }

            a /= f;
            r /= f;
            g /= f;
            b /= f;

            return Color.FromArgb((int)a, (int)r, (int)g, (int)b);
        }

        public static bool IsBright(Bitmap bitmap)
        {
            return IsBrightColor(Average(bitmap));
        }

        public static bool IsBrightColor(Color color)
        {
            return 127 < ((color.R + color.G + color.B) / 3);
        }

        public static Bitmap ColorChange(Bitmap bitmap, Color color)
        {
            Bitmap after = new Bitmap(bitmap.Width, bitmap.Height);

            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++)
                    after.SetPixel(
                        x, y, Color.FromArgb(
                            bitmap.GetPixel(x, y).A,
                            color
                        )
                    );

            return after;
        }
    }
}