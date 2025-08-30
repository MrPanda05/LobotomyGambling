using Char;
using Commons.Autoloads;
using Godot;
using System;

namespace Test
{
    public partial class TestLevel : Node2D
    {
        public override void _Ready()
        {
            MinigameManager.Instance.StartMinigame(0);
        }
    }
}
