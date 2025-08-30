using Godot;
using System;

namespace Gun.Ammo
{
    /// <summary>
    /// Interface for bullet behavior.
    /// </summary>
    public interface IBullet
    {
        float Speed { get; set; }
        float Damage { get; set; }
        float LifeTime { get; set; }
        int Penetration { get; set; }
        public void Initialize(Vector2 direction, float speed, float damage, float lifeTime, int penetration);
    }
}
