using Char;
using Commons.FiniteStateMachine;
using Godot;
using System;


namespace Enemies.States
{

    public partial class Follow : State
    {
        private EnemyBase _enemy;
        private Player _player;
        public override void Start()
        {
            _enemy = FiniteStateMachine.GetParent<EnemyBase>();
            _player = GetTree().GetFirstNodeInGroup("Player") as Player;
        }

        public override void FixUpdate(float delta)
        {
            _enemy.Velocity = (_enemy.GlobalPosition.DirectionTo(_player.GlobalPosition)) * _enemy.EnemyResource.Speed;
            _enemy.MoveAndSlide();
        }
    }
}
