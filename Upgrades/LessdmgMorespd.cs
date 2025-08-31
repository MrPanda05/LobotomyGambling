using Godot;
using Gun;
using System;

namespace Upgrades
{
    [GlobalClass]
    public partial class LessdmgMorespd : UpgradeSource
    {
        [Export]
        public float DamageMultiplier { get; set; } = 0.8f;
        [Export]
        public float SpeedMultiplier { get; set; } = 1.2f;
        public override void ApplyGunUpgrade(IGun gun)
        {
            base.ApplyGunUpgrade(gun);
            gun.GunResource.Damage *= DamageMultiplier;
        }
        public override void ApplyPlayerUpgrade(Char.Player player)
        {
            base.ApplyPlayerUpgrade(player);
            player.ChangeSpeed(player.Speed * SpeedMultiplier);
        }
        public LessdmgMorespd() : this(0, 0, "") { }
        public LessdmgMorespd(float damageMultiplier, float speedMultiplier, string effectDescription) : base(effectDescription)
        {
            DamageMultiplier = damageMultiplier;
            SpeedMultiplier = speedMultiplier;
        }
    }
}
