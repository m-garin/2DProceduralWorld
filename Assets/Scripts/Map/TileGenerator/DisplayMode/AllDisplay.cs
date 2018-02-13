using System.Collections.Generic;
using UnityEngine;

namespace ProceduralWorld.Map.Tiles.Display.All
{
    /// <summary>
    /// Класс AllDisplay
    /// Отображения всех тайлов в зоне видимости
    /// </summary>
    public class AllDisplay : IDisplayMode<ITile>
    {
        readonly protected Dictionary<Vector2Int, ITile> tiles;

        public AllDisplay()
        {
            tiles = new Dictionary<Vector2Int, ITile>();
        }

        public void CheckIn(ITile _tile)
        {
            tiles.Add(_tile.Position, _tile);
            _tile.ShowPrefab();
        }

        public void CheckOut(Vector2Int _position)
        {
            ITile tile;
            if (tiles.TryGetValue(_position, out tile))
            {
                tile.DestroyPrefab();
                tiles.Remove(tile.Position);
            }
        }

        public void DestroyAll()
        {
            foreach (ITile tile in tiles.Values)
            {
                tile.DestroyPrefab();
            }
        }
    }
}