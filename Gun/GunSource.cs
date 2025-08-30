using Godot;
using System;

namespace Gun
{
    [GlobalClass]
    public partial class GunSource : Resource
    {
        [Export]
        public string GunName { get; set; } = "Pistol";
        [Export]
        public float Damage { get; set; } = 1;
        [Export]
        public float FireRate { get; set; } = 0.5f;
        [Export]
        public int MaxAmmo { get; set; } = 10;
        [Export]
        public float ReloadTime { get; set; } = 1f;
        [Export]
        public float BulletSpeed { get; set; } = 400f;
        [Export]
        public float BulletLifeTime { get; set; } = 2f;
        [Export]
        public int Penetration { get; set; } = 0;
        [Export]
        public int Pellets { get; set; } = 1;
        [Export]
        public PackedScene BulletScene { get; set; }
        [Export]
        public AudioStream ShootSound { get; set; }
        [Export]
        public AudioStream ReloadSound { get; set; }
        [Export]
        public Texture2D GunTexture { get; set; }

        public GunSource() : this("", 0, 0, 0, 0, 0, 0, 0, 0, null, null, null, null) { }

        public GunSource(string gunName, int damage, float fireRate, int maxAmmo, float reloadTime, float bulletSpeed, float bulletLifeTime, int penetration, int pellets, Texture2D gunTexture, PackedScene bulletScene, AudioStream shootSound, AudioStream reloadSound)
        {
            GunName = gunName;
            Damage = damage;
            FireRate = fireRate;
            MaxAmmo = maxAmmo;
            ReloadTime = reloadTime;
            BulletSpeed = bulletSpeed;
            BulletLifeTime = bulletLifeTime;
            Penetration = penetration;
            Pellets = pellets;
            GunTexture = gunTexture;
            BulletScene = bulletScene;
            ShootSound = shootSound;
            ReloadSound = reloadSound;
        }
    }
}
