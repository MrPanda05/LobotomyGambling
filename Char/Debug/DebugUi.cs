using Commons.Autoloads;
using Godot;
using System;

namespace Char.Debug
{
    public partial class DebugUi : CanvasLayer
    {
        public override void _PhysicsProcess(double delta)
        {
            if(!GameManager.Instance.IsDebugMode) return;
            if(Input.IsActionJustPressed("DebugUiToggle"))
            {
                GD.Print("tEST");
                Visible = !Visible;
            }
        }
    }
}
