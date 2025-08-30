using Char.States;
using Commons.Autoloads;
using Commons.Components;
using Commons.FiniteStateMachine;
using Godot;
using Gun;
using Minigames;
using System;
using System.Threading;

namespace Char
{
    public partial class Player : CharacterBody2D, IHaveFSM
    {
        [Export]
        public float Speed { get; private set; } = 250f;
        [Export]
        public float Acel { get; private set; } = 10f;
        [Export]
        public float Decel { get; private set; } = 10f;

        public Action OnPlayerStatsUpdate;


        private HealthComponent _healthComponent;
        private HurtboxComponent _hurtbox;
        private FSM _fsm;
        private Vector2 _vel;
        public GunManager GunManager { get; private set; }

        public override void _Ready()
        {
            _fsm = GetNode<FSM>("FSM");
            GunManager = GetNode<GunManager>("GunManager");
            _hurtbox = GetNode<HurtboxComponent>("HurtboxComponent");
            _healthComponent = GetNode<HealthComponent>("HealthComponent");
            _healthComponent.OnDeath += Die;
            _hurtbox.OnHit += OnHurt;
            MinigameManager.OnMinigameStart += EnterMinigame;
        }
        private void OnHurt(float damage)
        {
            //add other logic here like flashing red or knockback, imunity frames
            GD.Print("Player got hit: " + damage);
            _healthComponent.TakeDamage(damage);
        }
        private void Die()
        {
            GD.Print("Player Died");
        }
        public void Movement()
        {
            var inputVector = new Vector2(Input.GetAxis("Left", "Right"),Input.GetAxis("Up", "Down")).Normalized();
            _vel = Velocity;
            _vel = _vel.Lerp(inputVector * Speed, Acel * (float)GetProcessDeltaTime());
            if (inputVector == Vector2.Zero)
                _vel = _vel.Lerp(Vector2.Zero, Decel * (float)GetProcessDeltaTime());
            Velocity = _vel;
            MoveAndSlide();
        }
        public void EnterMinigame(IMinigame minigame)
        {
            _fsm.TransitioToState("MiniGame");
            if(_fsm.States["MiniGame"] is MiniGame state)
            {
                state.SetMinigame(minigame);
            }
        }
        public Vector2 ShootInput()
        {
            if(Input.IsActionPressed("ShotUp"))
            {
                return Vector2.Up;
            }
            else if(Input.IsActionPressed("ShotDown"))
            {
                return Vector2.Down;
            }
            else if(Input.IsActionPressed("ShotLeft"))
            {
                return Vector2.Left;
            }
            else if(Input.IsActionPressed("ShotRight"))
            {
                return Vector2.Right;
            }
            return Vector2.Zero;
        }
        public void ChangeSpeed(float newSpeed)
        {
            Speed = newSpeed;
        }
        public void ChangeAcel(float newAcel)
        {
            Acel = newAcel;
        }
        public void ChangeDecel(float newDecel)
        {
            Decel = newDecel;
        }
        public void DecreaseaxHealth(float amount)
        {
            _healthComponent.SetMaxHealth(_healthComponent.Health - amount);
            OnPlayerStatsUpdate?.Invoke();
        }

        public void RequestStateChange(string stateName)
        {
            if(_fsm == null)
            {
                _fsm.ForceNullState();
                return;
            }
            _fsm.TransitioToState(stateName);
        }
        public FSM GetFSM()
        {
            return _fsm;
        }
    }
}
