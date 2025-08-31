using Godot;
using System;

namespace Commons.Components
{
    public partial class HealthComponent : Node
    {
        [Export]
        public bool RoundToInt { get; set; } = false;
        [Export]
        public float MaxHealth { get; private set; } = 100f;
        [Export]
        public float Health { get; private set; } = 100f;
        public bool IsDead { get; private set; } = false;

        public Action OnHealthChange;
        public Action OnDeath;

        /// <summary>
        /// Does Damage to the entity, if health goes to 0 or below, triggers OnDeath event
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(float damage)
        {
            if (IsDead) return;
            Health -= damage;
            if (RoundToInt) Health = (int)Health;
            if (Health < 0)
            {
                Health = 0;
                OnDeath?.Invoke();
            }
            OnHealthChange?.Invoke();
        }
        /// <summary>
        /// Heals the entity, if health goes above max health, sets it to max health
        /// This is the same as using TakeDamage with a negative value
        /// </summary>
        /// <param name="healAmount"></param>
        public void Heal(float healAmount)
        {
            if (IsDead) return;
            Health += healAmount;
            if (RoundToInt) Health = (int)Health;
            if (Health > MaxHealth)
                Health = MaxHealth;
            OnHealthChange?.Invoke();
        }
        /// <summary>
        /// Sets the max health to a specific value, used for set up or debug purposes
        /// </summary>
        /// <param name="newMaxHealth"></param>
        public void SetMaxHealth(float newMaxHealth)
        {
            MaxHealth = newMaxHealth;
            if(MaxHealth < 0)
            {
                MaxHealth = 0;
                Health = 0;
            }
            if (RoundToInt) MaxHealth = (int)MaxHealth;
            if(Health > MaxHealth)
            {
                Health = MaxHealth;
            }
            OnHealthChange?.Invoke();
        }
        /// <summary>
        /// Set the current health to a specific value, used only for set up or debug purposes
        /// </summary>
        /// <param name="newHealth"></param>
        public void SetHealth(float newHealth)
        {
            Health = newHealth;
            if(RoundToInt) Health = (int)Health;
            OnHealthChange?.Invoke();
        }
        /// <summary>
        /// Fully heals the entity to max health
        /// </summary>
        public void FullyHeal()
        {
            Health = MaxHealth;
            if (RoundToInt) Health = (int)Health;
            OnHealthChange?.Invoke();
        }
    }
}
