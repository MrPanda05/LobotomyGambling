using Commons.Components;
using Godot;
using Gun.Ammo;
using System;
using static Godot.TextServer;

namespace Enemies
{
    public partial class BoneBullet : CharacterBody2D, IBullet
    {
        [Export]
        public float Speed { get; set; }
        [Export]
        public float Damage { get; set; }
        public float LifeTime { get; set; } = 2.5f;
        public int Penetration { get; set; }

        private Vector2 _direction;
        private HitboxComponenent _hitbox;
        private Timer _lifeTimer;
        public override void _Ready()
        {
            _lifeTimer = GetNode<Timer>("Lifetime");
            _hitbox = GetNode<HitboxComponenent>("HitboxComponenent");
            _lifeTimer.WaitTime = LifeTime;
            _lifeTimer.Start();
            _hitbox.SetDamage(Damage);
            _hitbox.OnBodyHit += SelfDestroy;
        }
        public void SelfDestroy()
        {
            QueueFree();
        }
        public override void _PhysicsProcess(double delta)
        {
            Velocity = _direction * Speed;
            MoveAndSlide();
        }
        public void Initialize(Vector2 direction, float speed = 0, float damage = 1, float lifeTime = 5, int penetration = 0)
        {
            _direction = direction.Normalized();
        }
    }
}
