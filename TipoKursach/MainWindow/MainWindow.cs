using System;
using System.Drawing;
using System.Windows.Forms;

namespace TipoKursach
{
    public partial class MainWindow : Form
    {
        private ParticleSystem _particleSystem;

        private Particle _cureentParticle;

        private ColorCircle _colorCircle;

        public MainWindow()
        {   
            InitializeComponent();

            _particleSystem = new ParticleSystem();

            PbMain.Image = new Bitmap(PbMain.Width, PbMain.Height);
            GenerateSettings.pbMain = PbMain;

            DirectionSelector.DataSource = Enum.GetValues(typeof(Direction));

            InitGenerationBar();
            InitColorCircle();
        }

        private void InitGenerationBar()
        {
            _particleSystem.OnGenerationUpdate += () =>
            {
                if (GenerationBar.Maximum < 49)
                {
                    UpdateGenerationBar();
                }
            };
        }

        private void UpdateGenerationBar()
        {
            GenerationBar.Maximum++;
            GenerationBar.Value++;
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

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            _particleSystem.IsActive = !_particleSystem.IsActive;
        }

        private void RenderObjs()
        {
            var particles = _particleSystem.GetParticles();

            using (var g = Graphics.FromImage(PbMain.Image))
            {
                g.Clear(Color.White);

                foreach (var particle in particles.ToArray())
                {
                    particle.Draw(g);
                }

                _colorCircle.Draw(g);
            }

            PbMain.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GenerationBar.Value != GenerationBar.Maximum)
            {
                if (_particleSystem.IsActive)
                    GenerationBar.Value++;
            }
            else
            {
                _particleSystem.UpdateGeneration(_colorCircle);
            }

            RenderObjs();
        }

        private void SpeedBar_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = 40 + (SpeedBar.Maximum - SpeedBar.Value) * 50;
        }

        private void NextStepButton_Click(object sender, EventArgs e)
        {
            if (GenerationBar.Value != GenerationBar.Maximum)
            {
                GenerationBar.Value++;
            } else
            {
                _particleSystem.UpdateGeneration(_colorCircle);
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            PbMain.Height = Height - 105;
            PbMain.Width = Width - 40;

            PbMain.Image = new Bitmap(PbMain.Width, PbMain.Height);
        }

        private void DirectionSelector_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GenerateSettings.direction = (Direction)DirectionSelector.SelectedItem;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            var particles = _particleSystem.GetParticles();

            foreach (var particle in particles)
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
                }
            }

            if (e.Button == MouseButtons.Right)
            {
                _colorCircle.SetCoordinates(e.X, e.Y);
            }
        }

        private void CircleSettingsBtn_Click(object sender, EventArgs e)
        {
            var circleForm = new ColorCIrcleSettings();
            circleForm.SetColorCircle(_colorCircle);
            circleForm.ShowDialog();
        }

        private void GenerationBar_ValueChanged(object sender, EventArgs e)
        {
            _particleSystem.SetGeneration(GenerationBar.Value);
        }

        public static bool IsLeftScreen(Particle particle)
        {
            return (particle.GetX() + particle.GetRadius() < 0
                || particle.GetX() > GenerateSettings.pbMain.Image.Width
                || particle.GetY() > GenerateSettings.pbMain.Image.Height);
        }

        private void GenerationBar_Scroll(object sender, EventArgs e)
        {
            _particleSystem.IsActive = false;
        }

        private void ParticlesCounter_ValueChanged(object sender, EventArgs e)
        {
            _particleSystem.SetParticlesLimit((int)ParticlesCounter.Value);
        }
    }
}
