using Godot;
using System;

namespace UI
{
    public partial class Menu : Control
    {
        [Export]
        private Control _settingsNode;
        public void OnButtonButtonDown()
        {
            GetTree().ChangeSceneToFile("res://Levels/Level1.tscn");
        }

        public void OnButton2ButtonDown()
        {
            Visible = false;
            _settingsNode.Visible = true;
        }

        public void OnButton3ButtonDown()
        {
            GetTree().Quit();
        }
    }
}
