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
        }

        private void InitParticles()
        {
            for (int i = 0; i < 1500; i++)
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
            if (_particles.Count == 0)
            {
                InitParticles();
            }

            timer1.Enabled = !timer1.Enabled;
            StartStopButton.Text = (timer1.Enabled) ? "Stop" : "Start";
        }

        private void UpdateParticlesState()
        {
            foreach (var particle in _particles.ToArray())
            {
                if (particle.IsLeftScreen(pictureBox1))
                {
                    _particles.Remove(particle);
                    _particles.Add(GenerateParticle());
                } else
                {
                    particle.Move();
                }
            }
        }

        private void UpdateFrame()
        {
            UpdateParticlesState();

            using (var g = Graphics.FromImage(pictureBox1.Image))
            {
                g.Clear(Color.White);

                foreach (var particle in _particles.ToArray())
                {
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

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Height = Height;
            pictureBox1.Width = Width;

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }
    }
}
