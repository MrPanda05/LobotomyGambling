using Godot;
using Gun.Ammo;
using System;

namespace Gun.Weapons
{
    public partial class ShotGun : Node2D, IGun
    {
        [Export]
        public GunSource GunResource { get; set; }
        [Export]
        private float spreadShot = 15f; // Spread angle in degrees
        private Sprite2D _gunSprite;
        private Timer _fireRateTimer;
        [Export]
        private Marker2D _spawnLocation;

        override public void _Ready()
        {
            _fireRateTimer = GetNode<Timer>("FireRateTimer");
            _gunSprite = GetNode<Sprite2D>("Sprite2D");
            _gunSprite.Texture = GunResource.GunTexture;
            _fireRateTimer.WaitTime = GunResource.FireRate;
            GunManager.OnGunStatsUpdate += UpDatateStats;
        }
        public void UpDatateStats()
        {
            _fireRateTimer.WaitTime = GunResource.FireRate;
        }
        private void SetGunRotation(Vector2 direction)
        {
            if (direction == Vector2.Zero) return;
            Rotation = direction.Angle();
            _gunSprite.FlipV = direction.X < 0;
        }
        public void Shoot(Vector2 direction)
        {
            if(direction == Vector2.Zero) return;
            if(!_fireRateTimer.IsStopped()) return;
            var bulletScene = GunResource.BulletScene;
            Position = direction * 33;
            SetGunRotation(direction);
            for (int i = 0; i < GunResource.Pellets; i++)
            {
                var spreadAngle = (float)GD.RandRange(-spreadShot, spreadShot); // Adjust spread angle as needed
                var rotatedDirection = direction.Rotated(Mathf.DegToRad(spreadAngle)).Normalized();
                var bulletPhysicalBody = bulletScene.Instantiate<CharacterBody2D>();
                var bulletScript = (IBullet)bulletPhysicalBody;
                bulletScript.Initialize(rotatedDirection, GunResource.BulletSpeed, GunResource.Damage, GunResource.BulletLifeTime, GunResource.Penetration);
                bulletPhysicalBody.Position = _spawnLocation.GlobalPosition;
                //adding type 3 update would go here
                GetTree().CurrentScene.AddChild(bulletPhysicalBody);
            }
            _fireRateTimer.Start();
        }
    }
}
