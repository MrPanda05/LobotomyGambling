using Commons.Autoloads;
using Godot;
using System;

namespace Sounds.Music
{
    public partial class PlayGlobalMusic : Node
    {
        [Export]
        public AudioStream Music { get; set; }

        public override void _Ready()
        {
            MusicPlayerGlobal.Instance.PlayMusic(Music);
        }
    }
}
