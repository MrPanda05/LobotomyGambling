using Godot;
using System;


namespace Commons.Autoloads
{
    public partial class MusicPlayerGlobal : Node
    {
        public static MusicPlayerGlobal Instance { get; private set; }

        [Export]
        private AudioStreamPlayer _musicPlayer;

        public override void _Ready()
        {
            if (Instance != null)
            {
                QueueFree();
                return;
            }
            Instance = this;
        }

        public void PlayMusic(AudioStream music)
        {
            _musicPlayer.Stop();
            _musicPlayer.Stream = music;
            _musicPlayer.Play();
        }
    }
}
