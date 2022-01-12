using System;
using System.Collections.Generic;

namespace TipoKursach
{
    class ParticleSystem
    {
        private List<List<Particle>> _generations = new List<List<Particle>>();
        private List<Particle> _particles = new List<Particle>();

        private ParticlesFactory _factory = new ParticlesFactory();

        private int _particlesLimit = 500;

        public event Action OnGenerationUpdate;

        public bool IsActive { get; set; }

        public ParticleSystem()
        {
            _generations.Add(_particles);
            IsActive = true;
        }

        public void SetParticlesLimit(int value)
        {
            _particlesLimit = value;
        }

        public void UpdateGeneration(ColorCircle colorCircle)
        {
            if (IsActive)
            {
                AddLastGeneration();
                UpdateParticlesState(colorCircle);
                AddGeneration();

                if (_generations.Count > 1)
                    OnGenerationUpdate?.Invoke();
            }
        }

        private void UpdateParticlesState(ColorCircle colorCircle)
        {
            ChangeParticlesCount();

            foreach (var particle in _particles.ToArray())
            {
                if (Form1.IsLeftScreen(particle))
                {
                    particle.Destroy();
                }
                else
                {
                    particle.Move();
                }

                if (colorCircle.OvelapsWith(particle))
                {
                    colorCircle.OverlapParticle(particle);
                }
            }
        }

        private void AddGeneration()
        {
            if (_generations.Count < 50)
            {
                _generations.Add(_particles);
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

            _generations[_generations.Count - 1] = lastGeneration;
        }

        public void SetGeneration(int id)
        {
            _particles = _generations[id];
        }

        private void ChangeParticlesCount()
        {
            for (int i = 0; i < 10; i++)
            {
                if (_particles.Count < _particlesLimit)
                {
                    _particles.Add(GetParticle());
                }
                else if (_particles.Count > _particlesLimit)
                {
                    _particles.RemoveAt(0);
                }
            }
        }

        public Particle GetParticle()
        {
            var particle = _factory.Create();

            particle.OnDestroy += (prt) =>
            {
                _particles.Remove(prt);
                _particles.Add(GetParticle());
            };

            return particle;
        }

        public List<Particle> GetParticles()
        {
            return _particles;
        }
    }
}
