using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace NUMC.WinUtils.Dialogs {
    public class LockBitmap {
        private readonly Bitmap source = null;
        private IntPtr Iptr = IntPtr.Zero;
        private BitmapData bitmapData = null;

        public byte[] Pixels { get; set; }
        public int Depth { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public LockBitmap(Bitmap source) => this.source = source;

        /// <summary>
        /// Lock bitmap data
        /// </summary>
        public void LockBits() {
            try {
                Width = source.Width;
                Height = source.Height;
                var PixelCount = Width * Height;
                var rect = new Rectangle(0, 0, Width, Height);
                Depth = Image.GetPixelFormatSize(source.PixelFormat);
                if (Depth != 8 && Depth != 24 && Depth != 32)
                    throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
                bitmapData = source.LockBits(rect, ImageLockMode.ReadWrite, source.PixelFormat);
                var step = Depth / 8;
                Pixels = new byte[PixelCount * step];
                Iptr = bitmapData.Scan0;
                Marshal.Copy(Iptr, Pixels, 0, Pixels.Length);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Unlock bitmap data
        /// </summary>
        public void UnlockBits() {
            try {
                Marshal.Copy(Pixels, 0, Iptr, Pixels.Length);
                source.UnlockBits(bitmapData);
            } catch (Exception ex) {
                throw ex;
            }
        }

        /// <summary>
        /// Get the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Color GetPixel(int x, int y) { 
            var clr = Color.Empty;
            var cCount = Depth / 8;
            var i = ((y * Width) + x) * cCount;
            if (i > Pixels.Length - cCount) throw new IndexOutOfRangeException();
            if (Depth == 32) clr = Color.FromArgb(Pixels[i + 3], Pixels[i + 2], Pixels[i + 1], Pixels[i]);
            if (Depth == 24) clr = Color.FromArgb(Pixels[i + 2], Pixels[i + 1], Pixels[i]);
            if (Depth == 8) clr = Color.FromArgb(Pixels[i], Pixels[i], Pixels[i]);
            return clr;
        }

        /// <summary>
        /// Set the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public void SetPixel(int x, int y, Color color) {
            int cCount = Depth / 8, i = ((y * Width) + x) * cCount;
            if (Depth == 32) {
                Pixels[i] = color.B;
                Pixels[i + 1] = color.G;
                Pixels[i + 2] = color.R;
                Pixels[i + 3] = color.A;
            } if (Depth == 24) {
                Pixels[i] = color.B;
                Pixels[i + 1] = color.G;
                Pixels[i + 2] = color.R;
            } if (Depth == 8)
                Pixels[i] = color.B;
        }
    }
}