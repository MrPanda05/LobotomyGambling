using Godot;
using System;

namespace Enemies
{
    [GlobalClass]
    public partial class EnemySource : Resource
    {
        [Export]
        public string EnemyName { get; set; } = "Enemy";
        [Export]
        public float MaxHealth { get; set; } = 10f;
        [Export]
        public float Speed { get; set; } = 100f;
        [Export]
        public int Damage { get; set; } = 1;
        [Export]
        public float AttackRange { get; set; } = 20f;
        [Export]
        public float AttackCooldown { get; set; } = 1f;
        [Export]
        public Texture2D EnemyTexture { get; set; }
        public EnemySource() : this("", 0, 0, 0, 0, 0, null) { }
        public EnemySource(string enemyName, float maxHealth, float speed, int damage, float attackRange, float attackCooldown, Texture2D enemyTexture)
        {
            EnemyName = enemyName;
            MaxHealth = maxHealth;
            Speed = speed;
            Damage = damage;
            AttackRange = attackRange;
            AttackCooldown = attackCooldown;
            EnemyTexture = enemyTexture;
        }
    }
}
