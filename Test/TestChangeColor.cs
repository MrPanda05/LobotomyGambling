using Godot;
using System;

namespace Test
{
    public partial class TestChangeColor : TileMapLayer
    {
        public override void _Ready()
        {
            GD.Print(TileSet.GetSource(1));
            var test = TileSet.GetSource(1) as TileSetAtlasSource;
            test.Texture = null;
        }
    }
}
