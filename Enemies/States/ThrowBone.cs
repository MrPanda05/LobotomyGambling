using Char;
using Commons.FiniteStateMachine;
using Godot;
using Gun.Ammo;
using System;

namespace Enemies.States
{
    public partial class ThrowBone : State
    {
        private Timer timer;
        private Player player;
        [Export]
        private PackedScene _bulletbone;
        private EnemyBase _enemybase;

        public override void Start()
        {
            _enemybase = GetParent().GetParent<EnemyBase>();
            timer = GetNode<Timer>("Timer");
        }
        public override void Enter()
        {
            timer.Start();
        }
        public void OnTimerTimeout()
        {
            GD.Print("bONE IN THE ROW");
            player = GetTree().GetFirstNodeInGroup("Player") as Player;
            var boneBody = _bulletbone.Instantiate<CharacterBody2D>();
            var boneScript = (IBullet)boneBody;
            var dir = player.GlobalPosition - _enemybase.GlobalPosition;
            boneScript.Initialize(dir, 0, 0, 0, 0);
            boneBody.GlobalPosition = _enemybase.GlobalPosition;
            GetTree().CurrentScene.AddChild(boneBody);
            FiniteStateMachine.TransitioToState("Wander");
        }
    }
}
