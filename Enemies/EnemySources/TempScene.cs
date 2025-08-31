using Godot;
using System;

public partial class TempScene : Control
{
    public override void _Ready()
    {
        CallDeferred("Change");
    }

    public void Change()
    {
        GetTree().ChangeSceneToFile("res://Levels/Level1.tscn");

    }
}
