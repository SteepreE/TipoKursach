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
        enum Direction
        {
            Top,
            Bottom,
            Center
        }

        public static Random rand = new Random();

        private List<Particle> _particles = new List<Particle>();

        private Direction _direction;

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            DirectionSelector.DataSource = Enum.GetValues(typeof(Direction));
        }

        private void InitParticles()
        {
            for (int i = 0; i < 15; i++)
            {
                var particle = GenerateParticle();

                _particles.Add(particle);
            }
        }

        private Particle GenerateParticle()
        {
            float angle, x, y;

            switch (_direction)
            {
                case Direction.Top:
                    x = rand.Next(pictureBox1.Image.Width);
                    y = 0;
                    angle = 225 + rand.Next(90);
                    break;
                case Direction.Bottom:
                    x = rand.Next(pictureBox1.Image.Width);
                    y = pictureBox1.Image.Height;
                    angle = 45 + rand.Next(90);
                    break;
                default:
                    x = pictureBox1.Image.Width / 2;
                    y = pictureBox1.Image.Height / 2;
                    angle = rand.Next(360);
                    break;
            }
                

            var particle = new Particle(
                x, y, angle,
                1 + rand.Next(10),
                2 + rand.Next(10),
                20 + rand.Next(100)
                );

            particle.OnDestroy += (prt) =>
            {
                _particles.Remove(prt);
                _particles.Add(GenerateParticle());
            };

            return particle;
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
                    particle.Destroy();
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

            pictureBox1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateFrame();
        }

        private void SpeedBar_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 40 + (SpeedBar.Maximum - SpeedBar.Value) * 50;
        }

        private void NextStepButton_Click(object sender, EventArgs e)
        {
            UpdateFrame();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Height = Height;
            pictureBox1.Width = Width;

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void DirectionSelector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _direction = (Direction)DirectionSelector.SelectedItem;

            _particles.Clear();
            InitParticles();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Particle selectedParticles = null;

            foreach (var particle in _particles)
            {
                if (Math.Pow(e.X - particle.GetX(), 2) +
                    Math.Pow(e.Y - particle.GetY(), 2) <= Math.Pow(particle.GetRadius(), 2))
                {
                    selectedParticles = particle;
                    break;
                }
            }

            if (selectedParticles != null)
            {
                InfoLabel.Text = selectedParticles.GetInfo();
                InfoLabel.Location = new Point(e.X, e.Y);
                InfoLabel.Visible = true;
            }
            else
            {
                InfoLabel.Visible = false;
            }
        }
    }
}
