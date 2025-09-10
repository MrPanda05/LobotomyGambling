using Godot;
using System;

namespace Sounds
{
    public partial class TempAudioPlayer : AudioStreamPlayer
    {
        public void OnFinished()
        {
            QueueFree();
        }
    }
}
