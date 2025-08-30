using Godot;
using System;

namespace Commons.Components
{
    /// <summary>
    /// The sole job of the hitbox is to detect hurtbox, once detected, send hurtbox the damage value
    /// </summary>
    public partial class HitboxComponenent : Area2D
    {
        public float Damage { get; private set; } = 10f;

        public Action OnAreaHit;
        public Action OnBodyHit;

        public void SetDamage(float damage)
        {
            Damage = damage;
        }

        public void OnAreaEntered(Area2D area)
        {
            if(area is HurtboxComponent hurtbox)
            {
                OnAreaHit?.Invoke();
                hurtbox.HandleHit(Damage);
                return;
            }
        }
        public void OnBodyEntered(Node2D body)
        {
            OnBodyHit?.Invoke();
        }
    }
}
