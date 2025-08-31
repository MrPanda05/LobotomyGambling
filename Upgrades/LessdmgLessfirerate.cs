using Godot;
using System;

namespace Upgrades
{
    [GlobalClass]
    public partial class LessdmgLessfirerate : UpgradeSource
    {
        [Export]
        public float DamageMultiplier { get; set; } = 0.8f;
        [Export]
        public float FireRateMultiplier { get; set; } = 0.8f;
        public override void ApplyGunUpgrade(Gun.IGun gun)
        {
            base.ApplyGunUpgrade(gun);
            gun.GunResource.Damage *= DamageMultiplier;
            gun.GunResource.FireRate *= FireRateMultiplier;
        }
        public LessdmgLessfirerate() : this(0, 0, "") { }
        public LessdmgLessfirerate(float damageMultiplier, float fireRateMultiplier, string effectDescription) : base(effectDescription)
        {
            DamageMultiplier = damageMultiplier;
            FireRateMultiplier = fireRateMultiplier;
        }
    }
}
