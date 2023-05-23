using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MyGame
{
    internal class Player
    {
        public float X;
        public float Y;
        public int Size;

        public float Speed;

        public List<Particle> particles = new List<Particle>();
        public int particleCount = 3;

        public bool onPlatform;
        public bool isJump;
        public bool haveDoubleJump = true;

        private int animCounter = 0;
        public int animStyle = 0;
        private int animSpeed = 14;

        public MyGame.Form1.Color color;

        public int Score;
        public bool isAlive;

        public float GravityValue;

        public Bitmap playerImg;

        public Player(int x, int y)
        {
            this.X = x;
            this.Y = y;
            Speed = 1.5f;
            onPlatform = false;
            this.Size = 64;
            isAlive = true;
            GravityValue = 0.1f;
            Score = 0;
            SetBlueColor();
            playerImg = new Bitmap($"{System.Environment.CurrentDirectory}\\gamecourse\\player_blue1.png");
            for (var i = 0; i < particleCount; i++)
            {
                this.particles.Add(new Particle(x, y, animStyle, (isJump || !onPlatform)));
            }
        }

        public void Animation()
        {
            if (animCounter % animSpeed == 0)
            {
                if (isJump || !onPlatform)
                    JumpAnimation();
                else
                    RunAnimation();
                ParticleAnimation();
            }         
            animCounter += (int)Speed;
        }

        private void ParticleAnimation()
        {
            for (var i = 0; i < particleCount-1; i++)
            {
                particles[i] = particles[i + 1];
                particles[i].X -= this.Speed * (i + 1)*5;
            }
            particles[particleCount-1] = new Particle(this.X - this.Speed * 10, this.Y, animStyle, (isJump || !onPlatform));
        }

        public void JumpAnimation()
        {
            if (animStyle < 3)
            {
                if (this.color == MyGame.Form1.Color.Red)
                {
                    this.playerImg = new Bitmap($"{System.Environment.CurrentDirectory}\\gamecourse\\player_red_jump{animStyle + 1}.png");
                }
                else
                {
                    this.playerImg = new Bitmap($"{System.Environment.CurrentDirectory}\\gamecourse\\player_blue_jump{animStyle + 1}.png");
                }
            }           
            if (animStyle < 2)
                animStyle++;
        }

        public void RunAnimation()
        {
            if (this.color == MyGame.Form1.Color.Red)
            {
                this.playerImg = new Bitmap($"{System.Environment.CurrentDirectory}\\gamecourse\\player_red{animStyle + 1}.png");              
            }
            else
            {
                this.playerImg = new Bitmap($"{System.Environment.CurrentDirectory}\\gamecourse\\player_blue{animStyle + 1}.png");
            }
            if (animStyle == 4)
                animStyle = 0;
            else
                animStyle++;
        }


        public void SetRedColor()
        {
            this.color = MyGame.Form1.Color.Red;
            animCounter = animSpeed;
        }

        public void SetBlueColor()
        {
            this.color = MyGame.Form1.Color.Blue;
            animCounter = animSpeed;
        }
    }
}
