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
        private enum Direction
        {
            Top,
            Bottom,
            Center
        }

        private Direction _direction;

        public static Random rand = new Random();
        public static List<Particle> _particles = new List<Particle>();
        public static ColorCircle _colorCircle;

        public Form1()
        {
            InitializeComponent();

            PbMain.Image = new Bitmap(PbMain.Width, PbMain.Height);
            DirectionSelector.DataSource = Enum.GetValues(typeof(Direction));

            InitColorCircle();
            StartStopTimer();
        }

        private void ChangeParticlesCount()
        {
            for (int i = 0; i < 10; i++)
            {
                if (_particles.Count < (int)ParticlesCounter.Value)
                {
                    _particles.Add(GenerateParticle());
                } else if (_particles.Count > (int)ParticlesCounter.Value)
                {
                    _particles.RemoveAt(0);
                }
            }
        }

        private void InitColorCircle()
        {
            _colorCircle = new ColorCircle(
                PbMain.Image.Width / 2,
                PbMain.Image.Height / 2,
                30
                );

            _colorCircle.OnParticleOverlap += (prt) =>
            {
                (prt as Particle).SetColor(_colorCircle.GetColor());
            };
        }

        private Particle GenerateParticle()
        {
            float angle, x, y;

            switch (_direction)
            {
                case Direction.Top:
                    x = rand.Next(PbMain.Image.Width);
                    y = 0;
                    angle = 225 + rand.Next(90);
                    break;
                case Direction.Bottom:
                    x = rand.Next(PbMain.Image.Width);
                    y = PbMain.Image.Height;
                    angle = 45 + rand.Next(90);
                    break;
                default:
                    x = PbMain.Image.Width / 2;
                    y = PbMain.Image.Height / 2;
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
            StartStopTimer();
        }

        private void StartStopTimer()
        {
            timer1.Enabled = !timer1.Enabled;
            StartStopButton.Text = (timer1.Enabled) ? "Stop" : "Start";
        }

        private void UpdateParticlesState()
        {
            ChangeParticlesCount();

            foreach (var particle in _particles.ToArray())
            {
                if (particle.IsLeftScreen(PbMain))
                {
                    particle.Destroy();
                } else
                {
                    particle.Move();
                }

                if (_colorCircle.OvelapsWith(particle))
                {
                    _colorCircle.OverlapParticle(particle);
                }
            }
        }

        private void UpdateFrame()
        {
            UpdateParticlesState();

            using (var g = Graphics.FromImage(PbMain.Image))
            {
                g.Clear(Color.White);

                foreach (var particle in _particles.ToArray())
                {
                    particle.Draw(g);
                }

                _colorCircle.Draw(g);
            }

            PbMain.Invalidate();
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
            PbMain.Height = Height - 105;
            PbMain.Width = Width - 40;

            PbMain.Image = new Bitmap(PbMain.Width, PbMain.Height);
        }

        private void DirectionSelector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            _direction = (Direction)DirectionSelector.SelectedItem;

            _particles.Clear();
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

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _colorCircle.SetCoordinates(e.X, e.Y);
            }

            if (e.Button == MouseButtons.Right)
            {
                if (Math.Pow(e.X - _colorCircle.GetX(), 2) +
                    Math.Pow(e.Y - _colorCircle.GetY(), 2) <= Math.Pow(_colorCircle.GetRadius(), 2))
                {
                    var circleForm = new ColorCIrcleSettings();
                    circleForm.ShowDialog();
                }
            }
        }
    }
}
