using Commons.Components;
using Godot;
using System;
using System.Collections.Generic;

namespace Gun.Ammo
{
    public partial class Bullet : CharacterBody2D, IBullet
    {
        public List<IBehaviour> Behaviours { get; private set; }
        public float Speed { get; set; }
        public float Damage { get; set; }
        public float LifeTime { get; set; }
        public int Penetration { get; set; }

        private int _currentPenetration = 0;

        private Vector2 _direction;
        private HitboxComponenent _hitbox;
        private Timer _lifeTimer;
        public override void _Ready()
        {
            _lifeTimer = GetNode<Timer>("LifeTimer");
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
        public void OnLifeTimerTimeout()
        {
            QueueFree();
        }

        public override void _PhysicsProcess(double delta)
        {
            Velocity = _direction * Speed;
            //if(Behaviours.Count != 0)
            //{
            //    foreach (var behaviour in Behaviours)
            //    {
            //        behaviour.OnUpdate(this, (float)delta);
            //    }
            //}
            MoveAndSlide();
        }

        public void Initialize(Vector2 direction, float speed, float damage, float lifeTime, int penetration)
        {
            _direction = direction.Normalized();
            Speed = speed;
            Damage = damage;
            LifeTime = lifeTime;
            Penetration = penetration;
        }
        public override void _ExitTree()
        {
            _hitbox.OnBodyHit -= SelfDestroy;
        }
    }

}
