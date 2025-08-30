using Godot;
using System;
using Commons.FiniteStateMachine;
using Gun;

namespace Char.States
{
    public partial class Playing : State
    {
        private Player _player;
        private GunManager _gunManager;
        public override void Start()
        {
            _player = FiniteStateMachine.GetParent<Player>();
            _gunManager = _player.GetNode<GunManager>("GunManager");
        }
        public override void FixUpdate(float delta)
        {
            _player.Movement();
            _gunManager.SetShootDirection(_player.ShootInput());
        }
    }
}
