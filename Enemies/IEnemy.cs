using Commons.FiniteStateMachine;
using Godot;
using System;

namespace Enemies
{
    public interface IEnemy
    {
        public EnemySource EnemyResource { get; set; }
        /// <summary>
        /// Finite State Machine to handle the enemy AI.
        /// </summary>
        public FSM FiniteStateMachine { get; }
        /// <summary>
        /// The logic of the enemy AI.
        /// </summary>
        /// <param name="delta"></param>
        public void Attack();
        /// <summary>
        /// Handles death of the enemy
        /// </summary>
        public void Die();
        public Action<IEnemy> OnDeath { get; set; }
    }
}
