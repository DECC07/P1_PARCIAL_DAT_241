/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dbordes9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap original = new Bitmap(pictureBox1.Image);
                Bitmap edgeDetected = DetectEdges(original);
                pictureBox1.Image = edgeDetected;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private Bitmap DetectEdges(Bitmap original)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);

            // Matrices de Sobel
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

            for (int y = 1; y < original.Height - 1; y++)
            {
                for (int x = 1; x < original.Width - 1; x++)
                {
                    int pixelX = (gx[0, 0] * original.GetPixel(x - 1, y - 1).R) + (gx[0, 1] * original.GetPixel(x, y - 1).R) + (gx[0, 2] * original.GetPixel(x + 1, y - 1).R) +
                                 (gx[1, 0] * original.GetPixel(x - 1, y).R) + (gx[1, 1] * original.GetPixel(x, y).R) + (gx[1, 2] * original.GetPixel(x + 1, y).R) +
                                 (gx[2, 0] * original.GetPixel(x - 1, y + 1).R) + (gx[2, 1] * original.GetPixel(x, y + 1).R) + (gx[2, 2] * original.GetPixel(x + 1, y + 1).R);

                    int pixelY = (gy[0, 0] * original.GetPixel(x - 1, y - 1).R) + (gy[0, 1] * original.GetPixel(x, y - 1).R) + (gy[0, 2] * original.GetPixel(x + 1, y - 1).R) +
                                 (gy[1, 0] * original.GetPixel(x - 1, y).R) + (gy[1, 1] * original.GetPixel(x, y).R) + (gy[1, 2] * original.GetPixel(x + 1, y).R) +
                                 (gy[2, 0] * original.GetPixel(x - 1, y + 1).R) + (gy[2, 1] * original.GetPixel(x, y + 1).R) + (gy[2, 2] * original.GetPixel(x + 1, y + 1).R);

                    int magnitude = (int)Math.Sqrt((pixelX * pixelX) + (pixelY * pixelY));
                    magnitude = magnitude > 255 ? 255 : magnitude;
                    magnitude = magnitude < 0 ? 0 : magnitude;

                    result.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude));
                }
            }

            return result;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
*/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dbordes9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image originalImage = Image.FromFile(openFileDialog.FileName);
                Bitmap resizedImage = ResizeImage(originalImage, 300, 300); // Cambia el tamaño según tus necesidades
                pictureBox1.Image = resizedImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap original = new Bitmap(pictureBox1.Image);
                Bitmap edgeDetected = DetectEdges(original);
                pictureBox2.Image = edgeDetected;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Has hecho clic en la imagen.");
        }

        private Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;

                using (var wrapMode = new System.Drawing.Imaging.ImageAttributes())
                {
                    wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        private Bitmap DetectEdges(Bitmap original)
        {
            Bitmap result = new Bitmap(original.Width, original.Height);

            // Matrices de Sobel
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

            for (int y = 1; y < original.Height - 1; y++)
            {
                for (int x = 1; x < original.Width - 1; x++)
                {
                    int pixelX = (gx[0, 0] * original.GetPixel(x - 1, y - 1).R) + (gx[0, 1] * original.GetPixel(x, y - 1).R) + (gx[0, 2] * original.GetPixel(x + 1, y - 1).R) +
                                 (gx[1, 0] * original.GetPixel(x - 1, y).R) + (gx[1, 1] * original.GetPixel(x, y).R) + (gx[1, 2] * original.GetPixel(x + 1, y).R) +
                                 (gx[2, 0] * original.GetPixel(x - 1, y + 1).R) + (gx[2, 1] * original.GetPixel(x, y + 1).R) + (gx[2, 2] * original.GetPixel(x + 1, y + 1).R);

                    int pixelY = (gy[0, 0] * original.GetPixel(x - 1, y - 1).R) + (gy[0, 1] * original.GetPixel(x, y - 1).R) + (gy[0, 2] * original.GetPixel(x + 1, y - 1).R) +
                                 (gy[1, 0] * original.GetPixel(x - 1, y).R) + (gy[1, 1] * original.GetPixel(x, y).R) + (gy[1, 2] * original.GetPixel(x + 1, y).R) +
                                 (gy[2, 0] * original.GetPixel(x - 1, y + 1).R) + (gy[2, 1] * original.GetPixel(x, y + 1).R) + (gy[2, 2] * original.GetPixel(x + 1, y + 1).R);

                    int magnitude = (int)Math.Sqrt((pixelX * pixelX) + (pixelY * pixelY));
                    magnitude = magnitude > 255 ? 255 : magnitude;
                    magnitude = magnitude < 0 ? 0 : magnitude;

                    result.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude));
                }
            }

            return result;
        }
    }
}
