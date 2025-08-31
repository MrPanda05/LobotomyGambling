using Godot;
using System;

public partial class WinUi : Control
{
    public void OnButtonButtonDown()
    {
        GetTree().Quit();
    }
    public void OnButton2ButtonDown()
    {
        GetTree().ChangeSceneToFile("res://Levels/Level1.tscn");
    }
}
