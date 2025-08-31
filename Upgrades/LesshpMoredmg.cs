using Char;
using Godot;
using Gun;
using System;

namespace Upgrades
{
    [GlobalClass]
    public partial class LesshpMoredmg : UpgradeSource
    {
        [Export]
        public float HealthDecrease { get; set; } = 1;
        [Export]
        public float DamageMultiplier { get; set; } = 1.5f;
        public override void ApplyGunUpgrade(IGun gun)
        {
            base.ApplyGunUpgrade(gun);
            gun.GunResource.Damage *= DamageMultiplier;
        }
        public override void ApplyPlayerUpgrade(Player player)
        {
            base.ApplyPlayerUpgrade(player);
            player.DecreaseaxHealth(HealthDecrease);
        }
        public LesshpMoredmg() : this(0, 0, "") { }
        public LesshpMoredmg(float healthDecrease, float damageMultiplier, string effectDescription) : base(effectDescription)
        {
            HealthDecrease = healthDecrease;
            DamageMultiplier = damageMultiplier;
        }

    }
}
