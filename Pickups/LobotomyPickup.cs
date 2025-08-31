using Char;
using Commons.Autoloads;
using Godot;
using System;

namespace Pickups
{
    public partial class LobotomyPickup : Node2D
    {
        [Export]
        public int minigame;
        public void OnArea2dBodyEntered(Player player)
        {
            MinigameManager.Instance.StartMinigame(minigame);
            QueueFree();
        }
    }
}
