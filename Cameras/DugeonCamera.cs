using Godot;
using Levels.Rooms;
using System;

namespace Cameras
{
    public partial class DugeonCamera : Camera2D
    {
        [Export]
        private int _tilesToMoveX = 10;
        [Export]
        private int _tilesToMoveY = 10;
        public void MoveCamera(Vector2 direction)
        {
            GD.Print("Moving Camera");
            GlobalPosition += new Vector2(direction.X * 16 * _tilesToMoveX, direction.Y * 16 * _tilesToMoveY); // assuming each tile is 16x16 and we want to move 10 tiles
        }
        public override void _Ready()
        {
            Door.OnChangeCameraDirection += MoveCamera;
        }
    }
}
