using Godot;
using System;

namespace Minigames
{
    public interface IMinigame
    {
        public void Start();
        public void End();
        public bool IsRunning { get; set; }
        public Action OnMinigameEnd { get; set; }
    }
}
