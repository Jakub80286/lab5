using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
namespace lab5
{
   
        public partial class Form1 : Form
        {

            Image img1;
            Image img2;
            Bitmap bit1;
            Bitmap bit2;

        int wysokosc, szerokosc, wys2, szer2; 

        public static Image zmienimg(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        public Form1()
            {
                InitializeComponent();

            }

            private void Form1_Load(object sender, EventArgs e)
            {
                img1 = pictureBox1.Image;
                img2 = pictureBox3.Image;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                img2 = zmienimg(img2, new Size(pictureBox3.Size.Width, pictureBox3.Size.Height));
                img1 = zmienimg(img1, new Size(pictureBox1.Size.Width, pictureBox1.Size.Height));
                bit1 = new Bitmap(img1);
                bit2 = new Bitmap(img2);
                wysokosc = bit1.Width;
                szerokosc = bit1.Height;
                wys2 = bit2.Width;
                szer2 = bit2.Height;

            }

          

            public int sprawdzKolor(int value)
            {
                if (value >= 255) return 254;
                if (value <= 0) return 1;
                else return value;
            }


        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color p = bit1.GetPixel(x, y);
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            pictureBox2.Image = bit1;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color img1Pix = bit1.GetPixel(x, y);
                    Color auroraPixel = bit2.GetPixel(x, y);
                    int a = sprawdzKolor(img1Pix.A + auroraPixel.A);
                    int r = sprawdzKolor(img1Pix.R + auroraPixel.R);
                    int g = sprawdzKolor(img1Pix.G + auroraPixel.G);
                    int b = sprawdzKolor(img1Pix.B + auroraPixel.B);


                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bit1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color tukanPixel = bit1.GetPixel(x, y);
                    Color auroraPixel = bit2.GetPixel(x, y);
                    int a = sprawdzKolor(tukanPixel.A + auroraPixel.A - 255);
                    int r = sprawdzKolor(tukanPixel.R + auroraPixel.R - 255);
                    int g = sprawdzKolor(tukanPixel.G + auroraPixel.G - 255);
                    int b = sprawdzKolor(tukanPixel.B + auroraPixel.B - 255);

                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bit1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color img1Pix = bit1.GetPixel(x, y);
                    Color img2Pix = bit2.GetPixel(x, y);
                    int a = img1Pix.A;
                    int r = sprawdzKolor(Math.Abs(img1Pix.R - img2Pix.R));
                    int g = sprawdzKolor(Math.Abs(img1Pix.G - img2Pix.G));
                    int b = sprawdzKolor(Math.Abs(img1Pix.B - img2Pix.B));

                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bit1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color img1Pix = bit1.GetPixel(x, y);
                    Color img2Pix = bit2.GetPixel(x, y);
                    int a = 255;
                    int r = sprawdzKolor(img1Pix.R * img2Pix.R);
                    int g = sprawdzKolor(img1Pix.G * img2Pix.G);
                    int b = sprawdzKolor(img1Pix.B * img2Pix.B);

                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bit1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color img1Pix = bit1.GetPixel(x, y);
                    Color img2Pix = bit2.GetPixel(x, y);
                    double a = sprawdzKolor(255 - sprawdzKolor((255 - img1Pix.A)) * sprawdzKolor(255 - img2Pix.B));
                    double r = sprawdzKolor(255 - sprawdzKolor((255 - img1Pix.R)) * sprawdzKolor(255 - img2Pix.R));
                    double g = sprawdzKolor(255 - sprawdzKolor((255 - img1Pix.G)) * sprawdzKolor(255 - img2Pix.G));
                    double b = sprawdzKolor(255 - sprawdzKolor((255 - img1Pix.B)) * sprawdzKolor(255 - img2Pix.B));
                    bit1.SetPixel(x, y, Color.FromArgb((int)a, (int)r, (int)g, (int)b));

                }
            }
            pictureBox2.Image = bit1;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color img1Pix = bit1.GetPixel(x, y);
                    Color img2Pix = bit2.GetPixel(x, y);
                    int a = 255;
                    int r = sprawdzKolor(255 - sprawdzKolor(Math.Abs(255 - img1Pix.R - img2Pix.R)));
                    int g = sprawdzKolor(255 - sprawdzKolor(Math.Abs(255 - img1Pix.G - img2Pix.G)));
                    int b = sprawdzKolor(255 - sprawdzKolor(Math.Abs(255 - img1Pix.B - img2Pix.B)));

                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bit1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color img1Pix = bit1.GetPixel(x, y);
                    Color img2Pix = bit2.GetPixel(x, y);
                    int a = 255, r, g, b;

                    if (img1Pix.R < img2Pix.R)
                        r = img2Pix.R;
                    else
                        r = img2Pix.R;

                    if (img1Pix.G < img2Pix.G)
                        g = img1Pix.G;
                    else
                        g = img2Pix.G;

                    if (img1Pix.B < img2Pix.B)
                        b = img1Pix.B;
                    else
                        b = img2Pix.B;


                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bit1;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color img1Pix = bit1.GetPixel(x, y);
                    Color img2Pix = bit2.GetPixel(x, y);
                    int a, r, g, b;
                    if (img1Pix.A > img2Pix.A)
                        a = img1Pix.A;
                    else
                        a = img2Pix.A;

                    if (img1Pix.R > img2Pix.R)
                        r = img2Pix.R;
                    else
                        r = img2Pix.R;

                    if (img1Pix.G > img2Pix.G)
                        g = img1Pix.G;
                    else
                        g = img2Pix.G;

                    if (img1Pix.B > img2Pix.B)
                        b = img1Pix.B;
                    else
                        b = img2Pix.B;


                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bit1;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color img1Pix = bit1.GetPixel(x, y);
                    Color img2Pix = bit2.GetPixel(x, y);
                    int a = 255;
                    int r = sprawdzKolor(img1Pix.R + img2Pix.R - sprawdzKolor(510 * img1Pix.R * img2Pix.R));
                    int g = sprawdzKolor(img1Pix.G + img2Pix.G - sprawdzKolor(510 * img1Pix.G * img2Pix.G));
                    int b = sprawdzKolor(img1Pix.B + img2Pix.B - sprawdzKolor(510 * img1Pix.B * img2Pix.B));

                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
                pictureBox2.Image = bit1;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color img1Pix = bit1.GetPixel(x, y);
                    Color img2Pix = bit2.GetPixel(x, y);
                    int a = 255, r, g, b;

                    if (img1Pix.R < 255 * 0.5)
                        r = sprawdzKolor(2 * img1Pix.R * img2Pix.R);
                    else
                        r = sprawdzKolor(1 - 2 * (1 - img1Pix.R) * (1 - img2Pix.R));

                    if (img1Pix.G < 255 * 0.5)
                        g = sprawdzKolor(2 * img1Pix.G * img2Pix.G);
                    else
                        g = sprawdzKolor(1 - 2 * (1 - img1Pix.G) * (1 - img2Pix.G));

                    if (img1Pix.B < 255 * 0.5)
                        b = sprawdzKolor(2 * img1Pix.B * img2Pix.B);
                    else
                        b = sprawdzKolor(1 - 2 * (1 - img1Pix.B) * (1 - img2Pix.B));


                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bit1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color img1Pix = bit1.GetPixel(x, y);
                    Color img2Pix = bit2.GetPixel(x, y);
                    int a = 255, r, g, b;

                    if (img2Pix.R < 255 * 0.5)
                        r = sprawdzKolor(510 * img1Pix.R * img2Pix.R);
                    else
                        r = sprawdzKolor(255 - 510 * (255 - img1Pix.R) * (255 - img2Pix.R));

                    if (img2Pix.G < 255 * 0.5)
                        g = sprawdzKolor(510 * img1Pix.G * img2Pix.G);
                    else
                        g = sprawdzKolor(255 - 510 * (255 - img1Pix.G) * (255 - img2Pix.G));

                    if (img2Pix.B < 255 * 0.5)
                        b = sprawdzKolor(510 * img1Pix.B * img2Pix.B);
                    else
                        b = sprawdzKolor(255 - 510 * (255 - img1Pix.B) * (510 - img2Pix.B));


                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bit1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color img1Pix = bit1.GetPixel(x, y);
                    Color img2Pix = bit2.GetPixel(x, y);
                    double a = 255, r, g, b;

                    if (img2Pix.R / 255 < 0.5)
                        r = sprawdzKolor(((int)(2 * img1Pix.R / 255 * img2Pix.R / 255 + Math.Pow(img1Pix.R / 255, 2) * (1 - 2 * img2Pix.R / 255))) * 255);
                    else
                        r = sprawdzKolor(((int)(Math.Sqrt(img1Pix.R / 255) * (2 * img2Pix.R / 255 - 1) + (2 * img1Pix.R / 255) * (1 - img2Pix.R / 255))) * 255);

                    if (img2Pix.G / 255 < 0.5)
                        g = sprawdzKolor(((int)(2 * img1Pix.G / 255 * img2Pix.G / 255 + Math.Pow(img1Pix.G / 255, 2) * (1 - 2 * img2Pix.G / 255))) * 255);
                    else
                        g = sprawdzKolor(((int)(Math.Sqrt(img1Pix.G / 255) * (2 * img2Pix.G / 255 - 1) + (2 * img1Pix.G / 255) * (1 - img2Pix.G / 255))) * 255);

                    if (img2Pix.B / 255 < 0.5)
                        b = sprawdzKolor(((int)(2 * img1Pix.B / 255 * img2Pix.B / 255 + Math.Pow(img1Pix.B / 255, 2) * (1 - 2 * img2Pix.B / 255))) * 255);
                    else
                        b = sprawdzKolor(((int)(Math.Sqrt(img1Pix.B / 255) * (2 * img2Pix.B / 255 - 1) + (2 * img1Pix.B / 255) * (1 - img2Pix.B / 255))) * 255);


                    bit1.SetPixel(x, y, Color.FromArgb((int)a, (int)r, (int)g, (int)b));

                }
            }
            pictureBox2.Image = bit1;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color tukanPixel = bit1.GetPixel(x, y);
                    Color auroraPixel = bit2.GetPixel(x, y);

                    int a = sprawdzKolor(tukanPixel.A / sprawdzKolor((255 - auroraPixel.A)));
                    int r = sprawdzKolor(tukanPixel.R / sprawdzKolor((255 - auroraPixel.R)));
                    int g = sprawdzKolor(tukanPixel.G / sprawdzKolor((255 - auroraPixel.G)));
                    int b = sprawdzKolor(tukanPixel.B / sprawdzKolor((255 - auroraPixel.B)));

                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bit1;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color img1Pix = bit1.GetPixel(x, y);
                    Color img2Pix = bit2.GetPixel(x, y);

                    int a = sprawdzKolor((int)(Math.Pow(img1Pix.A, 2) / sprawdzKolor(255 - img2Pix.A)));
                    int r = sprawdzKolor((int)(Math.Pow(img1Pix.R, 2) / sprawdzKolor(255 - img2Pix.R)));
                    int g = sprawdzKolor((int)(Math.Pow(img1Pix.G, 2) / sprawdzKolor(255 - img2Pix.G)));
                    int b = sprawdzKolor((int)(Math.Pow(img1Pix.B, 2) / sprawdzKolor(255 - img2Pix.B)));

                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bit1;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color img1Pix = bit1.GetPixel(x, y);
                    Color img2Pix = bit2.GetPixel(x, y);
                    int a = sprawdzKolor((trackBar2.Value * ((img2Pix.A + 64) - img1Pix.A)) / 256 + img1Pix.A - (trackBar2.Value / 4));
                    int r = sprawdzKolor((trackBar2.Value * ((img2Pix.R + 64) - img1Pix.R)) / 256 + img1Pix.R - (trackBar2.Value / 4));
                    int g = sprawdzKolor((trackBar2.Value * ((img2Pix.G + 64) - img1Pix.G)) / 256 + img1Pix.G - (trackBar2.Value / 4));
                    int b = sprawdzKolor((trackBar2.Value * ((img2Pix.B + 64) - img1Pix.B)) / 256 + img1Pix.B - (trackBar2.Value / 4));


                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bit1;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            pictureBox2.Image = Janosc(bit1, trackBar1.Value);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            bit1 = new Bitmap(img1);
            pictureBox2.Image = bit1;

        }

        private void button14_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < szerokosc; y++)
            {
                for (int x = 0; x < wysokosc; x++)
                {
                    Color img1Pix = bit1.GetPixel(x, y);
                    Color img2Pix = bit2.GetPixel(x, y);
                    int a = sprawdzKolor(255 - (255 - img1Pix.A) / sprawdzKolor(img2Pix.A));
                    int r = sprawdzKolor(255 - (255 - img1Pix.R) / sprawdzKolor(img2Pix.R));
                    int g = sprawdzKolor(255 - (255 - img1Pix.G) / sprawdzKolor(img2Pix.G));
                    int b = sprawdzKolor(255 - (255 - img1Pix.B) / sprawdzKolor(img2Pix.B));

                    bit1.SetPixel(x, y, Color.FromArgb(a, r, g, b));

                }
            }
            pictureBox2.Image = bit1;
        }


            public static Bitmap Janosc(Bitmap Image, int Value)
            {
                Bitmap bitt = Image;
                float wynik = (float)Value / 255.0f;
                Bitmap konbit = new Bitmap(bitt.Width, bitt.Height);
                Graphics newGraphics = Graphics.FromImage(konbit);
                float[][] floatColorMatrix =
                {
                new float[] {1,0,0,0,0},new float[] {0,1,0,0,0},new float[] {0,0,1,0,0},new float[] {0,0,0,1,0},new float[] {wynik,wynik,wynik,1,1}
                };
                ColorMatrix kolorMac = new ColorMatrix(floatColorMatrix);
                ImageAttributes attributes = new ImageAttributes();
                attributes.SetColorMatrix(kolorMac);
                newGraphics.DrawImage(bitt, new Rectangle(0, 0, bitt.Width, bitt.Height), 0, 0,
                    bitt.Width, bitt.Height, GraphicsUnit.Pixel, attributes);
                attributes.Dispose();
                newGraphics.Dispose();

                return konbit;
            }

          


        }
    }