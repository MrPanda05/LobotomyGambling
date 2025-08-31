using Char;
using Godot;
using System;

namespace Levels.Rooms
{
    public partial class Door : Node2D
    {
        [Export]
        public Door LikedDoor { get; private set; }
        [Export]
        public Marker2D ExitPoint { get; private set; }// the point where the player will be placed when exiting through this door
        public BaseRoom ParentRoom { get; private set; }
        private StaticBody2D _collisionBody;
        [Export]
        public Vector2 ChangeDirection { get; private set; } = Vector2.Zero;
        public static Action<Vector2> OnChangeCameraDirection;

        [Export]
        private Texture2D _openDoor, _closeDoor;
        [Export]
        private Sprite2D _doorSprite;
        public override void _Ready()
        {
            ParentRoom = GetParent<BaseRoom>();
            _collisionBody = GetNode<StaticBody2D>("DoorSolid");
            ParentRoom.OnRoomCleared += UnlockDoor;
            _doorSprite.Scale = new Vector2(1.722f, 1.455f);
            _doorSprite.Texture = _closeDoor;
            if (ChangeDirection == new Vector2(1, 0))
            {
                _doorSprite.RotationDegrees = 90;
            }
            else if (ChangeDirection == new Vector2(-1, 0))
            {
                _doorSprite.RotationDegrees = -90;
            }
            else if (ChangeDirection == new Vector2(0, -1))
            {
                _doorSprite.RotationDegrees = 0;

            }
            else
            {
                _doorSprite.RotationDegrees = -180;
            }
            if (ExitPoint == null)
            {
                ExitPoint = GetNode<Marker2D>("Marker2D");
                if(ExitPoint == null)
                {
                    GD.PushWarning("Tried to get marker by failed: " + Name);
                }
                else
                {
                    GD.Print("Got marker by name: " + Name);
                }
            }
        }
        public void OnDoorTriggerBodyEntered(Player player)
        {
            GD.Print("Player entered door");
            OnChangeCameraDirection?.Invoke(ChangeDirection);
            if(LikedDoor == null)
            {
                GD.PushWarning("LikedDoor is not set for door: " + Name);
                return;
            }
            player.RequestStateChange("ExitingDoor");
            player.GlobalPosition = LikedDoor.ExitPoint.GlobalPosition;
        }
        private void UnlockDoor()
        {
            _collisionBody.ProcessMode = ProcessModeEnum.Disabled;
            _doorSprite.Texture = _openDoor;
        }
    }
}
