using Commons.FiniteStateMachine;
using Godot;
using System;

namespace Char.States
{
    public partial class ExitingDoor : State
    {
        private Player _player;
        private Timer _timer;
        public override void Start()
        {
            _player = FiniteStateMachine.GetParent<Player>();
            _timer = GetNode<Timer>("Timer");
        }
        public override void Enter()
        {
            _player.Velocity = Vector2.Zero;
            _player.MoveAndSlide();
            _timer.Start();
        }
        public void OnTimerTimeout()
        {
            FiniteStateMachine.TransitioToState("Playing");
        }
    }
}
