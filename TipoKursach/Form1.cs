using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

        private List<List<Particle>> _generations = new List<List<Particle>>();
        
        public static List<Particle> _particles = new List<Particle>();
        public static ColorCircle _colorCircle;

        private Particle _cureentParticle = null;

        public Form1()
        {
            InitializeComponent();

            PbMain.Image = new Bitmap(PbMain.Width, PbMain.Height);
            DirectionSelector.DataSource = Enum.GetValues(typeof(Direction));

            _generations.Add(_particles);

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
            if (GenerationBar.Value != GenerationBar.Maximum)
            {
                MessageBox.Show("NIZYA!");
                return;
            }

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

        public void AddNewGeneration()
        {
            if (GenerationBar.Maximum < 50)
            {
                _generations.Add(_particles);
                GenerationBar.Maximum += 1;
                GenerationBar.Value = GenerationBar.Maximum;
            }
            else
            {
                _generations.RemoveAt(0);
                _generations.Add(_particles);
            }
        }

        private void AddLastGeneration()
        {
            var lastGeneration = new List<Particle>();

            foreach (var particle in _particles)
            {
                lastGeneration.Add(new Particle(particle));
            }

            _generations[GenerationBar.Maximum] = lastGeneration;
        }

        private void UpdateFrame()
        {
            RenderObjs();
        }

        private void RenderObjs()
        {
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

        public void UpdateGeneration()
        {
            AddLastGeneration();
            UpdateParticlesState();
            AddNewGeneration();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateGeneration();

            UpdateFrame();
        }

        private void SpeedBar_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 40 + (SpeedBar.Maximum - SpeedBar.Value) * 50;
        }

        private void NextStepButton_Click(object sender, EventArgs e)
        {
            if (GenerationBar.Value != GenerationBar.Maximum)
            {
                MessageBox.Show("NIZYA!");
                return;
            }

            UpdateGeneration();

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
            foreach (var particle in _particles)
            {
                if (Math.Pow(e.X - particle.GetX(), 2) +
                    Math.Pow(e.Y - particle.GetY(), 2) <= Math.Pow(particle.GetRadius(), 2))
                {
                    _cureentParticle = particle;

                    InfoLabel.Text = _cureentParticle.GetInfo();
                    InfoLabel.Location = new Point((int)_cureentParticle.GetX(), (int)_cureentParticle.GetY());
                    InfoLabel.Visible = true;

                    return;
                }
            }

            InfoLabel.Visible = false;
            _cureentParticle = null;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                if (_cureentParticle != null)
                {
                    if (!_cureentParticle.IsLocedInfo()) _cureentParticle.LockInfo();
                    else _cureentParticle.UnlockInfo();

                    RenderObjs();
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                _colorCircle.SetCoordinates((int)e.X, (int)e.Y);
            }
        }

        private void GenerationBar_Scroll(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            _particles = _generations[GenerationBar.Value];

            RenderObjs();
        }

        private void CircleSettingsBtn_Click(object sender, EventArgs e)
        {
            var circleForm = new ColorCIrcleSettings();
            circleForm.ShowDialog();
        }
    }
}
