using Char;
using Godot;
using Gun;
using System;
using Upgrades;

namespace Minigames
{
    public partial class LobotomyMinigame : Node2D, IMinigame
    {
        public bool IsRunning { get; set; }
        public Action OnMinigameEnd { get; set; }

        [Export]
        private AnimationPlayer _animPlayer;
        [Export]
        private Node2D _stickAngle;
        public Timer timer;

        [Export]
        private Button _lobotomyBtn, _exitBtn;

        [Export]
        private Label _desctEffectLabel;

        [Export]
        public UpgradeSource[] _upgrades;


        public override void _Ready()
        {
            timer = GetNode<Timer>("Timer");
        }
        public void End()
        {
            GD.Print("Lobotomy Minigame Ended");
            OnMinigameEnd?.Invoke();
            Visible = false;
            ProcessMode = ProcessModeEnum.Disabled;
            timer.Start();
        }
        public void OnExitButtonButtonDown()
        {
            End();
        }
        public void OnTimerTimeout()
        {

            QueueFree();
        }

        public void Start()
        {
            GD.Print("Lobotomy Minigame Started");
            _animPlayer.Play("Rotate");
            IsRunning = true;
        }
        public void OnButtonButtonDown()
        {
            AddEffect(_stickAngle.RotationDegrees);
            _animPlayer.Pause();
            _lobotomyBtn.Visible = false;
            _exitBtn.Visible = true;
        }
        private void AddEffect(float angle)
        {
            //upgrades shouldn't be herekkkkkkkkkkkkkkkkkk
            Player player = GetTree().GetFirstNodeInGroup("Player") as Player;
            if (_stickAngle.RotationDegrees >= 30 && _stickAngle.RotationDegrees < 50)
            {
                //player.ChangeSpeed(player.Speed * 1.1f);
                //player.GunManager.CurrentGun.GunResource.Damage *= 0.75f;
                _upgrades[0].ApplyPlayerUpgrade(player);
                _upgrades[0].ApplyGunUpgrade(player.GunManager.CurrentGun);
                GunManager.OnGunStatsUpdate?.Invoke();
            }
            else if (_stickAngle.RotationDegrees >= 50 && _stickAngle.RotationDegrees < 90)
            {
                //player.DecreaseaxHealth(1);
                //player.GunManager.CurrentGun.GunResource.Damage *= 1.1f;
                _upgrades[1].ApplyPlayerUpgrade(player);
                _upgrades[1].ApplyGunUpgrade(player.GunManager.CurrentGun);
                GunManager.OnGunStatsUpdate?.Invoke();
            }
            else
            {
                //player.GunManager.CurrentGun.GunResource.Damage *= 0.65f;
                //player.GunManager.CurrentGun.GunResource.FireRate *= 0.75f;
                _upgrades[2].ApplyPlayerUpgrade(player);
                _upgrades[2].ApplyGunUpgrade(player.GunManager.CurrentGun);
                GunManager.OnGunStatsUpdate?.Invoke();

            }
        }
        public override void _PhysicsProcess(double delta)
        {
            if(_stickAngle.RotationDegrees >= 30 && _stickAngle.RotationDegrees < 50)
            {
                _desctEffectLabel.Text = _upgrades[0].EffectDescription;//"Less damage, but more speed";
            }
            else if(_stickAngle.RotationDegrees >= 50 && _stickAngle.RotationDegrees < 90)
            {
                _desctEffectLabel.Text = _upgrades[1].EffectDescription;//"Less Max health, but more damage";

            }
            else
            {
                _desctEffectLabel.Text = _upgrades[2].EffectDescription; //"Less damage, but less firerate";
            }
        }
    }
}
