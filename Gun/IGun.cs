using Godot;
using System;

namespace Gun
{

    /// <summary>
    /// Guns are responsible for spawning bullets and applying upgrades of bullets.
    /// </summary>
    public interface IGun
    {
        public GunSource GunResource { get; set; }

        public void Shoot(Vector2 direction);
        //public void ApplyUpgrade(string upgradeType);
    }
}
