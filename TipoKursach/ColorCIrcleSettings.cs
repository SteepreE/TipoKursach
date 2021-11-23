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
    public partial class ColorCIrcleSettings : Form
    {
        public ColorCIrcleSettings()
        {
            InitializeComponent();
        }

        private void SetColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            ColorBox.Image = new Bitmap(ColorBox.Width, ColorBox.Height);

            var g = Graphics.FromImage(ColorBox.Image);

            g.Clear(colorDialog1.Color);
            Form1._colorCircle.SetColor(colorDialog1.Color);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Form1._colorCircle.SetRadius(RadiusSelector.Value);
        }
    }
}
