using Commons.FiniteStateMachine;
using Godot;
using Minigames;
using System;

namespace Char.States
{
    public partial class MiniGame : State
    {
        private IMinigame _miniGame;

        public void SetMinigame(IMinigame minigame)
        {
            _miniGame = minigame;
            _miniGame.OnMinigameEnd += OnMinigameEnd;
        }

        public void OnMinigameEnd()
        {
            FiniteStateMachine.TransitioToState("Playing");
            _miniGame.OnMinigameEnd -= OnMinigameEnd;
            _miniGame = null;
        }
    }
}
