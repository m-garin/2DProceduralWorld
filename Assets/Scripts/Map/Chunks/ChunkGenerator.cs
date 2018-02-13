using UnityEngine;

namespace ProceduralWorld.Map.Tiles
{
    public class ChunkGenerator
    {
        readonly TileGenerator tileGenerator;

        public ChunkGenerator(TileGenerator _tileGenerator)
        {
            tileGenerator = _tileGenerator;
        }

        delegate void ActionWithTile(Vector2Int _position);

        public void Add(int _xMin, int _yMin, int _xMax, int _yMax)
        {
            Loop(_xMin, _yMin, _xMax, _yMax, tileGenerator.Generate);
        }

        public void Remove(int _xMin, int _yMin, int _xMax, int _yMax)
        {
            Loop(_xMin, _yMin, _xMax, _yMax, tileGenerator.Remove);
        }

        void Loop(int _xMin, int _yMin, int _xMax, int _yMax, ActionWithTile _action)
        {
            for (int y = _yMin; y <= _yMax; y++)
            {
                for (int x = _xMin; x <= _xMax; x++)
                {
                    _action(new Vector2Int(x, y));
                }
            }
        }
    }
}
