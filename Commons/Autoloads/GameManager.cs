using Godot;
using System;

namespace Commons.Autoloads
{

    public partial class GameManager : Node
    {
        public static GameManager Instance { get; private set; }

        public RandomNumberGenerator RNG { get; private set; } = new RandomNumberGenerator();
        [Export]
        public bool IsDebugMode { get; set; } = false;

        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
            RNG.Randomize();
        }
    }
}
