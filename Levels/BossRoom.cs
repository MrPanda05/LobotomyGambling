using Godot;
using System;

namespace Levels.Rooms
{
    public partial class BossRoom : BaseRoom
    {
        public override void _Ready()
        {
            base._Ready();
            OnRoomCleared += WinGame;
            GD.Print("tHIS IS A BOS ROOM");
        }
        public void WinGame()
        {
            GD.Print("You beat al the levels!!");
            GetTree().ChangeSceneToFile("res://Levels/Level1.tscn");
        }
    }
}
