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

        private bool _isLockedInfo = false;

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

        public Particle(Particle particle)
        {
            _x = particle.GetX();
            _y = particle.GetY();
            _direction = particle.GetDirection();
            _speed = particle.GetSpeed();
            _radius = particle.GetRadius();
            _life = particle.GetLife();
            _color = particle.GetColor();
            _isLockedInfo = particle.IsLocedInfo();
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

            if (_life <= 0) Destroy();
        }

        public void Destroy()
        {
            OnDestroy?.Invoke(this);
        }

        public void SetColor(Color color)
        {
            _color = color;
        }

        public Color GetColor()
        {
            return _color;
        }

        public bool IsLeftScreen(PictureBox pictureBox)
        {
            return (_x + _radius < 0 
                || _x > pictureBox.Image.Width 
                || _y > pictureBox.Image.Height);
        }

        public bool IsLocedInfo()
        {
            return _isLockedInfo;
        }

        public String GetInfo()
        {
            return $"X: {_x}\n" +
                $"Y: {_y}\n" +
                $"Life: {_life}\n";
        }

        public float GetDirection()
        {
            return _direction;
        }

        public float GetSpeed()
        {
            return _speed;
        }

        public float GetLife()
        {
            return _life;
        }

        public float GetX()
        {
            return _x;
        }

        public float GetY()
        {
            return _y;
        }

        public int GetRadius()
        {
            return _radius;
        }

        public void LockInfo()
        {
            _isLockedInfo = true;
        }

        public void UnlockInfo()
        {
            _isLockedInfo = false;
        }

        public void ShowInfo(Graphics g)
        {
            using (Font font1 = new Font("Microsoft Sans Serif", 9, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                Point pos = new Point((int)_x, (int)_y);

                g.DrawString(GetInfo(), font1, Brushes.Black, pos);
            }
        }

        public void Draw(Graphics g)
        {
            if (_isLockedInfo) ShowInfo(g);

            float k = Math.Min(1f, _life / 100);
            int alpha = (int)(k * 255);
            var color = Color.FromArgb(alpha, _color);

            var b = new SolidBrush(color);

            g.FillEllipse(b, _x - _radius, _y - _radius, _radius * 2, _radius * 2);

            b.Dispose();
        }
    }
}
