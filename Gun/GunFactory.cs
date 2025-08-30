using Godot;
using System;

namespace Gun
{
    /// <summary>
    /// Factory class responsible for creating gun packedscnes based on provided paths.
    /// </summary>
    public partial class GunFactory : Node
    {
        [Export]
        public string[] WeaponsPath { get; set; }

        public PackedScene CreateGun(string path)
        {
            var scene = GD.Load<PackedScene>(path);
            if (scene == null)
            {
                GD.PrintErr($"Failed to load gun scene at path: {path}");
                return null;
            }
            return scene;
        }

    }
}
