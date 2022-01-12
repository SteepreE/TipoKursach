using System;
using System.Windows.Forms;

namespace TipoKursach
{
    class ParticlesFactory
    {
        private Random rand = new Random();

        public Particle Create()
        {
            float angle, x, y;

            switch (GenerateSettings.direction)
            {
                case Direction.Top:
                    x = rand.Next(GenerateSettings.pbMain.Image.Width);
                    y = 0;
                    angle = 225 + rand.Next(90);
                    break;
                case Direction.Bottom:
                    x = rand.Next(GenerateSettings.pbMain.Image.Width);
                    y = GenerateSettings.pbMain.Image.Height;
                    angle = 45 + rand.Next(90);
                    break;
                default:
                    x = GenerateSettings.pbMain.Image.Width / 2;
                    y = GenerateSettings.pbMain.Image.Height / 2;
                    angle = rand.Next(360);
                    break;
            }

            var particle = new Particle(
                x, y, angle,
                1 + rand.Next(10),
                2 + rand.Next(10),
                20 + rand.Next(100)
                );

            return particle;
        }
    }

    class GenerateSettings
    {
        public static Direction direction = Direction.Top;
        public static PictureBox pbMain;
    }
}
