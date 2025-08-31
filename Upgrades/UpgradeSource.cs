using Char;
using Godot;
using Gun;
using System;

namespace Upgrades
{
    [GlobalClass]
    public partial class UpgradeSource : Resource
    {
        [Export]
        public string EffectDescription { get; set; } = "Upgrade Effect";
        public virtual void ApplyGunUpgrade(IGun gun) 
        {
            GD.Print("Applying upgrade to gun");
        }
        public virtual void ApplyPlayerUpgrade(Player player) 
        {
            GD.Print("Applying upgrade to player");
        }
        public UpgradeSource() : this("") { }
        public UpgradeSource(string effectDescription)
        {
            EffectDescription = effectDescription;
        }
    }
}
