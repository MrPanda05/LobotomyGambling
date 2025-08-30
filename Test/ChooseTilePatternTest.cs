using Godot;
using System;

namespace Test
{
    public partial class ChooseTilePatternTest : TileMapLayer
    {
        [Export]
        public Vector2I spawnFirstRoom = new Vector2I(0,0);
        public override void _Ready()
        {
            var tileid = (int)(GD.Randi() % 2);
            var pattern = TileSet.GetPattern(tileid);
            GD.Print(pattern.GetSize());
            SetPattern(Vector2I.Zero, pattern);
            SetPattern(spawnFirstRoom, pattern);
            foreach (var cell in GetUsedCells())
            {
                //IndentifyCellType(cell);
                //SubstituteTile(cell, new Vector2I(3, 0));
                //if(IsCellType(cell, new Vector2I(3,0)))
                //{
                //    SubstituteTile(cell, new Vector2I(0, 0));
                //}
            }
        }

        private void IndentifyCellType(Vector2I cell)
        {
            var tileid = GetCellAtlasCoords(cell);
            if (tileid == Vector2I.Zero)
            {
                GD.Print($"Cell: {cell}, is a hole");
            }
            else if (tileid == new Vector2I(1, 0))
            {
                GD.Print($"Cell: {cell}, is a wall");
            }
            else if (tileid == new Vector2I(2, 0))
            {
                GD.Print($"Cell: {cell}, is a door");
            }
            else if (tileid == new Vector2I(3, 0))
            {
                GD.Print($"Cell: {cell}, is a floor");
            }
        }
        private bool IsCellType(Vector2I cell, Vector2I atlas)
        {
            var tileid = GetCellAtlasCoords(cell);
            return tileid == atlas;
        }

        private void SubstituteTile(Vector2I cell, Vector2I atlas)
        {
           SetCell(cell, 1, atlas);
        }
    }
}
