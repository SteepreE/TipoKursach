using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipoKursach
{
    public partial class Form1 : Form
    {
        public static Random rand = new Random();

        private List<Particle> _particles = new List<Particle>();

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            InitParticles();
        }

        private void InitParticles()
        {
            for (int i = 0; i < 500; i++)
            {
                var particle = GenerateParticle();

                _particles.Add(particle);
            }
        }

        private Particle GenerateParticle()
        {
            return new Particle(
                rand.Next(pictureBox1.Width),
                0,
                225 + rand.Next(90),
                1 + rand.Next(10),
                2 + rand.Next(10)
                );
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            StartStopButton.Text = (timer1.Enabled) ? "Stop" : "Start";
        }

        private void UpdateFrame()
        {
            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                g.Clear(Color.White);

                foreach (var particle in _particles)
                {
                    particle.Move();
                    particle.Draw(g);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateFrame();
            pictureBox1.Invalidate();
        }

        private void SpeedBar_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 40 + (SpeedBar.Maximum - SpeedBar.Value) * 50;
        }

        private void NextStepButton_Click(object sender, EventArgs e)
        {
            UpdateFrame();
            pictureBox1.Invalidate();
        }
    }
}
