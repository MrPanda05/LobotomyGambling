using Godot;
using System;

namespace Char
{
    public partial class HeartUI : TextureRect
    {
        [Export]
        public Texture2D FullHeart { get; set; }
        [Export]
        public Texture2D EmptyHeart { get; set; }
    }
}
