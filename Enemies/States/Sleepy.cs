using Commons.FiniteStateMachine;
using Godot;
using System;

namespace Enemies.States
{
    public partial class Sleepy : State
    {
        private EnemyBase _enemy;
        public override void Start()
        {
            _enemy = FiniteStateMachine.GetParent<EnemyBase>();
            _enemy.Ready += AwaitReady;
        }
        private void AwaitReady()
        {
            _enemy.Hurtbox.OnHit += WakeUp;
            _enemy.Ready -= AwaitReady;
        }
        public override void Enter()
        {
            if(_enemy.Hurtbox != null)
            {
                _enemy.Hurtbox.OnHit += WakeUp;
            }

        }
        public override void Exit()
        {
            _enemy.Hurtbox.OnHit -= WakeUp;
        }
        private void WakeUp(float damage)
        {
            FiniteStateMachine.TransitioToState("Follow");
        }
    }
}
