using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    internal class Particle
    {
        public float X;
        public float Y;
        public Image particleImg;
        private int Alpha = 150;

        public Particle(float x, float y, int animStyle, bool isJump)
        {
            this.X = x;
            this.Y = y;
            if (isJump || animStyle < 3)
                this.particleImg = new Bitmap($"{System.Environment.CurrentDirectory}\\gamecourse\\particles\\player_jump3.png");
            else
                this.particleImg = new Bitmap($"{System.Environment.CurrentDirectory}\\gamecourse\\particles\\player_run1.png");
        }

        private Image SetAlpha(Bitmap image)
        {
            Bitmap bmp = new Bitmap(image.Width, image.Height);
            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    bmp.SetPixel(i, j, Color.FromArgb(this.Alpha, image.GetPixel(i, j).R, image.GetPixel(i, j).G, image.GetPixel(i, j).B));
                }
            }
            return bmp;
        }
    }
}
