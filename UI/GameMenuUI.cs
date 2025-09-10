using Godot;
using System;

namespace UI
{

    public partial class GameMenuUI : CanvasLayer
    {

        public override void _PhysicsProcess(double delta)
        {
            if (Input.IsActionJustPressed("pause"))
            {
                GetTree().Paused = !GetTree().Paused;
                Visible = !Visible;
            }
        }

        public void OnButtonButtonDown()
        {
            GetTree().Quit();
        }

        public void OnReturnButtonButtonDown()
        {
            if (GetTree().Paused)
            {
                GetTree().Paused = false;
                Visible = false;
            }
        }
    }
}
