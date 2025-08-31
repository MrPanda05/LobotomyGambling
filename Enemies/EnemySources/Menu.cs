using Godot;
using System;

public partial class Menu : Control
{
    public void OnButtonButtonDown()
    {
        GetTree().ChangeSceneToFile("res://Levels/Level1.tscn");
    }

    public void OnButton3ButtonDown()
    {
        GetTree().Quit();
    }
}
