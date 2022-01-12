using System;
using System.Drawing;
using System.Windows.Forms;

namespace TipoKursach
{
    public partial class ColorCIrcleSettings : Form
    {
        private ColorCircle _colorCircle;

        public ColorCIrcleSettings()
        {
            InitializeComponent();
        }

        private void SetColorButton_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            SetColorBox();
            _colorCircle.SetColor(colorDialog1.Color);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _colorCircle.SetRadius(RadiusSelector.Value);
        }

        public void SetColorCircle(ColorCircle colorCircle)
        {
            _colorCircle = colorCircle;

            RadiusSelector.Value = _colorCircle.GetRadius();
            colorDialog1.Color = _colorCircle.GetColor();
            SetColorBox();
        }

        private void SetColorBox()
        {
            ColorBox.Image = new Bitmap(ColorBox.Width, ColorBox.Height);
            var g = Graphics.FromImage(ColorBox.Image);

            g.Clear(colorDialog1.Color);
        }
    }
}
