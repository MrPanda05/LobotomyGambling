using Godot;
using Minigames;
using System;

namespace Commons.Autoloads
{
    public partial class MinigameManager : Node
    {
        public static MinigameManager Instance { get; private set; }

        [Export]
        public PackedScene[] MiniGames { get; private set; }

        public static Action<IMinigame> OnMinigameStart;
        [Export]
        public AudioStreamPlayer minigameSoundEffectStart;

        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
        }
        public void StartMinigame(int id)
        {
            var minigame = MiniGames[id].Instantiate();
            GetTree().CurrentScene.AddChild(minigame);
            minigame.Call("Start");
            minigameSoundEffectStart?.Play();
            OnMinigameStart?.Invoke((IMinigame)minigame);
        }
    }
}
