using Commons.FiniteStateMachine;
using Godot;
using System;

namespace Enemies.States
{
    public partial class Wander : State
    {
        [ExportGroup("Configuration")]
        [Export]
        private float _speed = 140f; // The speed at which the enemy wanders.

        [Export]
        private float _wanderTime = 3.0f; // The duration of the wander state.

        [Export]
        private float _wanderRadius = 250f; // The radius to pick a random wander point in.

        [Export]
        public string stateOnWanderFinish;

        [ExportGroup("Node References")]
        [Export]
        private EnemyBase _enemy; // Assign this from the inspector.

        [Export]
        private Timer _timer; // Assign this from the inspector.

        private Vector2 _wanderTargetPosition;
        private RandomNumberGenerator _rng = new RandomNumberGenerator();

        public override void Start()
        {
            // This is a good place for validation checks.
            if (_enemy == null)
            {
                GD.PrintErr("Wander State: EnemyBase node is not assigned.");
            }
            if (_timer == null)
            {
                GD.PrintErr("Wander State: Timer node is not assigned.");
            }
        }

        public override void Enter()
        {
            // Pick a new random point to wander towards.
            var randomDirection = Vector2.Right.Rotated(_rng.RandfRange(0, (float)Math.PI * 2));
            _wanderTargetPosition = _enemy.GlobalPosition + (randomDirection * _rng.RandfRange(0, _wanderRadius));

            // Start the timer with the configured duration.
            _timer.Start(_wanderTime);
            GD.Print("time to wander");
        }

        public override void FixUpdate(float delta)
        {
            // Stop moving if we're close to the target to prevent jittering.
            if (_enemy.GlobalPosition.DistanceTo(_wanderTargetPosition) < 5f)
            {
                _enemy.Velocity = Vector2.Zero;
                return;
            }

            // Move towards the target.
            var direction = _enemy.GlobalPosition.DirectionTo(_wanderTargetPosition);
            _enemy.Velocity = direction * _speed;
            _enemy.MoveAndSlide();
        }

        // This should be connected to the Timer's "timeout" signal in the Godot Editor.
        private void OnTimerTimeout()
        {
            if(stateOnWanderFinish == Name)
            {
                _timer.Start(_wanderTime);
            }
            FiniteStateMachine.TransitioToState(stateOnWanderFinish);
        }
    }
}