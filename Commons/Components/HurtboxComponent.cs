using Godot;
using System;

namespace Commons.Components
{
    /// <summary>
    /// The job of the hurtbox is to get notified by the hitbox and send a signal, the one that listen to the signal will handle the damage or any other effect
    /// </summary>
    public partial class HurtboxComponent : Area2D
    {
        public Action<float> OnHit;
        public void HandleHit(float damage)
        {
            OnHit?.Invoke(damage);
        }
    }
}
