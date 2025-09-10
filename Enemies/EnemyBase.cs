using Commons.Autoloads;
using Commons.Components;
using Commons.FiniteStateMachine;
using Godot;
using System;

namespace Enemies
{
    public partial class EnemyBase : CharacterBody2D, IEnemy
    {
        [Export]
        public EnemySource EnemyResource { get; set; }
        public FSM FiniteStateMachine { get; protected set; }
        public HitboxComponenent Hitbox { get; protected set; }
        public HurtboxComponent Hurtbox { get; protected set; }
        public HealthComponent HealthComponenet { get; protected set; }
        public Action<IEnemy> OnDeath { get; set; }

        private Sprite2D _sprite;

        [Export]
        private AudioStream _hitAudio;
        [Export]
        private AudioStream _deathSound;

        public override void _Ready()
        {
            FiniteStateMachine = GetNode<FSM>("FSM");
            Hitbox = GetNode<HitboxComponenent>("HitboxComponenent");
            Hurtbox = GetNode<HurtboxComponent>("HurtboxComponent");
            HealthComponenet = GetNode<HealthComponent>("HealthComponent");
            _sprite = GetNode<Sprite2D>("Sprite2D");
            _sprite.Texture = EnemyResource.EnemyTexture;
            Hitbox.OnAreaHit += TestHitBox;
            Hitbox.SetDamage(EnemyResource.Damage);
            Hurtbox.OnHit += TestHurtBox;
            HealthComponenet.SetMaxHealth(EnemyResource.MaxHealth);
            HealthComponenet.SetHealth(EnemyResource.MaxHealth);
            HealthComponenet.OnDeath += Die;

        }

        public void TestHitBox()
        {
            GD.Print("I hit something");
        }
        public void TestHurtBox(float damage)
        {
            //add other logic here like flashing red or knockback
            GD.Print("I got hit: " + damage);
            //_hitAudio?.Play();
            AudioManager.Instance.PlaySound(_hitAudio, 0.8f, 1.3f, "SFX");
            HealthComponenet.TakeDamage(damage);
        }
        public virtual void Attack()
        {
        }

        public virtual void Die()
        {
            OnDeath?.Invoke(this);
            AudioManager.Instance.PlaySound(_deathSound, 0.8f, 1.3f, "SFX");
            QueueFree();
        }
        public override void _ExitTree()
        {
            Hitbox.OnAreaHit -= TestHitBox;
            HealthComponenet.OnDeath -= Die;
            Hurtbox.OnHit -= TestHurtBox;
        }
    }
}
