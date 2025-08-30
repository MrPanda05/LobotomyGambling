using Godot;
using System;

namespace Char.Debug
{

    public partial class DebugWindow : Panel
    {
        [Export]
        private Panel _player, _gun, _bullet;

        [Export]
        public MenuButton _button;

        public override void _Ready()
        {
            _button.GetPopup().IdPressed += ChangeVisiblePanel;
        }
        public void OnMenuButtonButtonDown()
        {
            GD.Print(_button.Text);
        }

        private void ChangeVisiblePanel(long id)
        {
            _player.Visible = false;
            _gun.Visible = false;
            _bullet.Visible = false;
            switch (id)
            {
                case 0:
                    _player.Visible = true;
                    break;
                case 1:
                    _gun.Visible = true;
                    break;
                case 2:
                    _bullet.Visible = true;
                    break;
                default:
                    break;
            }
        }
    }
}
