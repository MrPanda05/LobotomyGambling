using Godot;
using System;
using Char;

namespace Gun
{
    /// <summary>
    /// I am responsible for applying gun upgrades, changing guns, and shooting the gun.
    /// </summary>
    public partial class GunManager : Node2D
    {
        private Player _player;
        private Vector2 _shootDirection;
        private string _currentPlayerState;
        public IGun CurrentGun { get; private set; }

        private GunFactory _gunFactory;
        private GunHolder _gunHolder;

        public static Action OnGunStatsUpdate;

        public override void _Ready()
        {
            _player = GetParent<Player>();
            _gunFactory = GetNode<GunFactory>("GunFactory");
            _gunHolder = GetNode<GunHolder>("GunHolder");
            _player.Ready += InitializeThis;

            InstantiateGun("res://Gun/Weapons/ShotGun.tscn");//start the first gun
        }
        private void InitializeThis()
        {
            _player.GetFSM().OnStateChangeTo += OnStateChange;
            _currentPlayerState = _player.GetFSM().GetCurrentStateName();
            _player.Ready -= InitializeThis;
        }
        private void InstantiateGun(string gunPath)
        {
            var gun = _gunFactory.CreateGun(gunPath).Instantiate<Node2D>();
            CurrentGun = (IGun)gun;
            //add gun upgrades here
            _gunHolder.EquipGun(gun);
        }
        private void OnStateChange(string newState)
        {
            _currentPlayerState = newState;
        }

        public void SetShootDirection(Vector2 dir)
        {
            if (_currentPlayerState != "Playing") return;
            _shootDirection = dir;
        }
        private void ChangeGun()
        {
            CurrentGun = null;
            _gunHolder.UnequipGun();
        }
        private void ApplyGunUpgrades()
        {
        }

        public override void _PhysicsProcess(double delta)
        {
            if (_currentPlayerState != "Playing") return;
            if(CurrentGun == null) return;
            CurrentGun.Shoot(_shootDirection);
        }
    }
}
