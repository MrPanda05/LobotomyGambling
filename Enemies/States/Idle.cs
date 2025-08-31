using Commons.FiniteStateMachine;
using Godot;
using System;

namespace Enemies.States
{
    public partial class Idle : State
    {
        [Export]
        public string stateName;
        [Export]
        private Timer timer;

        public override void Enter()
        {
            timer.Start();
        }
        public void OnTimerTimeout()
        {
            FiniteStateMachine.TransitioToState(stateName);
        }
    }
}
