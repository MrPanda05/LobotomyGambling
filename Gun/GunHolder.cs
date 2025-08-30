using Godot;
using System;

namespace Gun
{
    /// <summary>
    /// Responsible for holding and managing the equipped gun.
    /// </summary>
    public partial class GunHolder : Node2D
    {
        private Node2D _currentGun;
        public bool IsEmpty { get; private set; }
        public void EquipGun(Node2D gun)
        {
            if (_currentGun != null)
            {
                _currentGun.QueueFree();
            }
            _currentGun = gun;
            AddChild(_currentGun);
            _currentGun.Position = new Vector2(33,0);
            IsEmpty = false;
        }
        public void UnequipGun()
        {
            if (_currentGun != null)
            {
                _currentGun.QueueFree();
                _currentGun = null;
            }
            IsEmpty = true;
        }
    }
}
