using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TipoKursach
{
    public class Particle
    {
        private float _x;
        private float _y;

        private float _direction;
        private float _speed;

        private int _radius;

        private float _life;
        private Color _color = Color.Black;

        public Action<Particle> OnDestroy;

        public Particle(float x, float y, float direction, float speed, int radius, float life)
        {
            _x = x;
            _y = y;
            _direction = direction;
            _speed = speed;
            _radius = radius;
            _life = life;
        }

        public void Move()
        {
            var directionInRadians = _direction / 180 * Math.PI;
            _x += (float)(_speed * Math.Cos(directionInRadians));
            _y -= (float)(_speed * Math.Sin(directionInRadians));

            Distruction();
        }

        private void Distruction()
        {
            _life--;

            if (_life == 0) Destroy();
        }

        public void Destroy()
        {
            OnDestroy?.Invoke(this);
        }

        public void SetColor(Color color)
        {
            _color = color;
        }

        public bool IsLeftScreen(PictureBox pictureBox)
        {
            return (_x + _radius < 0 
                || _x > pictureBox.Image.Width 
                || _y > pictureBox.Image.Height);
        }

        public String GetInfo()
        {
            return $"X: {_x}\n" +
                $"Y: {_y}\n" +
                $"Life: {_life}\n";
        }

        public float GetX()
        {
            return _x;
        }

        public float GetY()
        {
            return _y;
        }

        public float GetRadius()
        {
            return _radius;
        }

        public void Draw(Graphics g)
        {
            float k = Math.Min(1f, _life / 100);
            int alpha = (int)(k * 255);
            var color = Color.FromArgb(alpha, _color);

            var b = new SolidBrush(color);

            g.FillEllipse(b, _x - _radius, _y - _radius, _radius * 2, _radius * 2);

            b.Dispose();
        }
    }
}
