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
        }

        private void InitParticles()
        {
            for (int i = 0; i < 500; i++)
            {
                var particle = GenerateParticle();


            }
        }

        private Particle GenerateParticle()
        {
            return new Particle(
                rand.Next(360),
                0,
                rand.Next(180),
                1 + rand.Next(360),
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
    }
}
