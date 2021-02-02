using System.Drawing;

namespace NUMC.Design.Resources
{
    public static class Images
    {
        public static Bitmap Default
        {
            get
            {
                return DrawingFail(16);

                /*
                #if DEBUG
                    return DrawingFail(16);
                #else
                    return new Bitmap(0, 0);
                #endif
                */
            }
        }

        public static Bitmap GetImage(string name, bool bright = true)
        {
            try {
                object obj = Design.Images.ResourceManager.GetObject(name);

                if (obj == null || obj.GetType() != typeof(Bitmap))
                    return Default;

                if (bright)
                    return (Bitmap)obj;
                else
                    return Render.Reversal((Bitmap)obj);
            } catch {
                return Default;
            }
        }

        private static Bitmap DrawingFail(int size = 32)
        {
            Bitmap bitmap = new Bitmap(size, size);
            Color color = Color.Red;
            int s = 0, e = bitmap.Width - 1;

            for (int h = 0; h < bitmap.Height; h++)
            {
                bitmap.SetPixel(s++, h, color);
                bitmap.SetPixel(e--, h, color);
            }

            return bitmap;
        }
    }
}