using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace TipoKursach
{
    public class ColorCircle
    {
        private float _x;
        private float _y;

        private Color _color = Color.Red;
        
        private int _radius;

        public Action<Particle> OnParticleOverlap;

        public ColorCircle(float x, float y, int radius)
        {
            _x = x;
            _y = y;
            _radius = radius;
        }

        public void OverlapParticle(Particle particle)
        {
            OnParticleOverlap?.Invoke(particle);
        }

        public bool OvelapsWith(Particle particle)
        {
            float gX = _x - particle.GetX();
            float gY = _y - particle.GetY();

            double r = Math.Sqrt(gX * gX + gY * gY);
            return (r + particle.GetRadius() < _radius);
        }

        public void SetColor(Color color)
        {
            _color = color;
        }

        public Color GetColor()
        {
            return _color;
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

        public void SetRadius(int radius)
        {
            _radius = radius;
        }

        public void SetCoordinates(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public void Draw(Graphics g)
        {
            var b = new Pen(_color, 3);

            g.DrawEllipse(b, _x - _radius, _y - _radius, _radius * 2, _radius * 2);

            b.Dispose();
        }
    }
}
