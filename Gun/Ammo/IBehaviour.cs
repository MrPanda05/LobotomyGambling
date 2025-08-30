using Godot;
using System;

namespace Gun.Ammo
{
    public interface IBehaviour
    {
        public void OnHit(IBullet bullet);
        public void OnUpdate(IBullet bullet, float delta);
    }
}
