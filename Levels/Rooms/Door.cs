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
        public override void _Ready()
        {
            ParentRoom = GetParent<BaseRoom>();
            _collisionBody = GetNode<StaticBody2D>("DoorSolid");
            ParentRoom.OnRoomCleared += UnlockDoor;
        }
        public void OnDoorTriggerBodyEntered(Player player)
        {
            GD.Print("Player entered door");
            if(LikedDoor == null)
            {
                GD.PushWarning("LikedDoor is not set for door: " + Name);
                return;
            }
            player.RequestStateChange("ExitingDoor");
            player.GlobalPosition = LikedDoor.ExitPoint.GlobalPosition;
            OnChangeCameraDirection?.Invoke(ChangeDirection);
        }
        private void UnlockDoor()
        {
            _collisionBody.ProcessMode = ProcessModeEnum.Disabled;
        }
    }
}
