﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipoKursach
{
    class Particle
    {
        private float _x;
        private float _y;

        private float _direction;
        private float _speed;

        private int _radius;

        public Particle(float x, float y, float direction, float speed, int radius)
        {
            _x = x;
            _y = y;
            _direction = direction;
            _speed = speed;
            _radius = radius;
        }

        public void Draw(Graphics g)
        {
            var b = new SolidBrush(Color.Black);

            g.FillEllipse(b, _x - _radius, _y - _radius, _radius * 2, _radius * 2);

            b.Dispose();
        }
    }
}