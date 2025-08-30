using Godot;
using Levels.Rooms;
using System;
using System.Collections.Generic;

namespace Levels
{
    public partial class LevelManager : Node2D
    {
        public List<BaseRoom> Rooms { get; private set; } = new List<BaseRoom>();
        public BaseRoom CurrentRoom { get; private set; }

        public Action OnDungeonClear;

        public override void _Ready()
        {
            foreach (var item in GetChildren())
            {
                if(item is BaseRoom room)
                {
                    Rooms.Add(room);
                    if (room.FirstRoom)
                    {
                        CurrentRoom = room;
                        room.OnRoomEnter();
                    }
                }
            }
            BaseRoom.OnRoomClearStatic += CheckIfDungeonIsAllClear;
            GD.Print(CurrentRoom.Name);
        }

        public void CheckIfDungeonIsAllClear()
        {
            foreach (var item in Rooms)
            {
                if (!item.IsCleared) return;
            }
            GD.Print("Dungeon Cleared!");
            OnDungeonClear?.Invoke();
        }
        public void ChangeRoom(BaseRoom newRoom)
        {
            if(newRoom == CurrentRoom) { return; }
            CurrentRoom.OnRoomExit();
            CurrentRoom = newRoom;
            CurrentRoom.OnRoomEnter();
        }
    }
}
