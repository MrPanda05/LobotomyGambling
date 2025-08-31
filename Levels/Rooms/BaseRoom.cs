using Char;
using Enemies;
using Godot;
using System;
using System.Collections.Generic;

namespace Levels.Rooms
{
    public partial class BaseRoom : Node2D
    {
        [Export]
        private TileMapLayer _tileMapLayer;
        [Export]
        private Door[] _doors;
        private List<IEnemy> _enemies = new List<IEnemy>();
        public bool IsCleared { get; private set; } = false;
        [Export]
        public bool FirstRoom { get; private set; } = false;
        [Export]
        public Marker2D PlayerSpawnPoint { get; private set; }

        public Action OnRoomCleared;
        public static Action OnRoomClearStatic;

        [Export]
        private Area2D _roomArea;
        private LevelManager _levelManager;

        public override void _Ready()
        {
            //set player pos
            if(_roomArea == null)
            {
                _roomArea = GetNodeOrNull<Area2D>("RoomArea");
                if(_roomArea == null)
                {
                    GD.PushWarning("RoomArea is not set for room: " + Name);
                }
            }
            _levelManager = GetParent<LevelManager>();
            foreach (var item in GetChildren())
            {
                if (item is IEnemy enemy)
                {
                    _enemies.Add(enemy);
                    IsCleared = false;
                    enemy.OnDeath += EnemyDied;
                }
            }
            if(_enemies.Count == 0)
            {
                IsCleared = true;
                OnRoomCleared?.Invoke();
                OnRoomClearStatic?.Invoke();
            }

            this._roomArea.BodyEntered += OnRoomAreaBodyEntered;
            this._roomArea.BodyExited += OnRoomAreaBodyExited;
            GD.Print("Enemies in room: " + _enemies.Count);
            if (!FirstRoom)
            {
                foreach (var item in GetChildren())
                {
                    if (item is Area2D)
                    {
                        continue;
                    }
                    item.ProcessMode = ProcessModeEnum.Disabled;
                }
            }
        }
        public override void _ExitTree()
        {
            this._roomArea.BodyEntered -= OnRoomAreaBodyEntered;
            this._roomArea.BodyExited -= OnRoomAreaBodyExited;
        }
        public void OnRoomAreaBodyEntered(Node2D player)
        {

            GD.Print("Player entered room: " + Name + "Status: " + IsCleared);
            _levelManager.ChangeRoom(this);
        }
        public void OnRoomAreaBodyExited(Node2D player)
        {
            GD.Print("Player exited room: " + Name);
        }
        public void EnemyDied(IEnemy enemy)
        {
            enemy.OnDeath -= EnemyDied;
            _enemies.Remove(enemy);
            GD.Print("Enemy died, remaining enemies: " + _enemies.Count);
            if (_enemies.Count == 0)
            {
                IsCleared = true;
                OnRoomCleared?.Invoke();
                OnRoomClearStatic?.Invoke();
                GD.Print("Room Cleared!");
            }
        }

        public virtual void OnRoomEnter()
        {
            foreach (var item in GetChildren())
            {
                if (item is Area2D)
                {
                    continue;
                }
                item.ProcessMode = ProcessModeEnum.Inherit;
            }
            GD.Print("Entered room: " + Name);
        }
        public virtual void OnRoomExit()
        {
            foreach (var item in GetChildren())
            {
                if(item is Area2D)
                {
                    continue;
                }
                    item.ProcessMode = ProcessModeEnum.Disabled;
            }
            GD.Print("Exited room: " + Name);
        }
    }
}
