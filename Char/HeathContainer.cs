using Godot;
using System;
using System.Collections.Generic;

namespace Char
{
    public partial class HeathContainer : HBoxContainer
    {
        public List<HeartUI> Hearts { get; private set; } = new List<HeartUI>();

        [Export]
        public PackedScene HeartScene { get; set; }

        [Export]
        private Player _player;
        public override void _Ready()
        {
            _player.Ready += StartHearts;
            _player.OnPlayerStatsUpdate += () => UpdateHearts(_player._healthComponent.Health, _player._healthComponent.MaxHealth);
        }
        public override void _ExitTree()
        {
            _player.Ready -= StartHearts;
        }

        public void StartHearts()
        {
            _player._hurtbox.OnHit += HandleDamage;
            for (int i = Hearts.Count; i < _player._healthComponent.MaxHealth; i++)
            {
                var heart = HeartScene.Instantiate<HeartUI>();
                Hearts.Add(heart);
                AddChild(heart);
            }
        }
        public void HandleDamage(float damage)
        {
            UpdateHearts(_player._healthComponent.Health, _player._healthComponent.MaxHealth);
        }

        public void UpdateHearts(float currentHealth, float maxHealth)
        {
            if (Hearts.Count < (int)maxHealth)
            {
                for (int i = Hearts.Count; i < (int)maxHealth; i++)
                {
                    var heart = HeartScene.Instantiate<HeartUI>();
                    Hearts.Add(heart);
                    AddChild(heart);
                }
            }
            else if (Hearts.Count > (int)maxHealth)
            {
                for (int i = Hearts.Count - 1; i >= (int)maxHealth; i--)
                {
                    RemoveChild(Hearts[i]);
                    Hearts[i].QueueFree();
                    Hearts.RemoveAt(i);
                }
            }
            for (int i = 0; i < Hearts.Count; i++)
            {
                if (i < (int)currentHealth)
                    Hearts[i].Texture = Hearts[i].FullHeart;
                else
                    Hearts[i].Texture = Hearts[i].EmptyHeart;
            }
        }
    }
}
