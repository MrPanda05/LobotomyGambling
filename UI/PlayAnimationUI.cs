using Godot;
using System;

namespace UI
{
    public partial class PlayAnimationUI : AnimationPlayer
    {
        [Export]
        private string _animName;

        public override void _Ready()
        {
            Play(_animName);
        }
    }
}
