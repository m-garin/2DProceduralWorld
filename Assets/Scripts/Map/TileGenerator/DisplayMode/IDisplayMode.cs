using UnityEngine;

namespace ProceduralWorld.Map.Tiles.Display
{
    public interface IDisplayMode<TileType>
    {
        void CheckIn(TileType _tile);
        void CheckOut(Vector2Int _position);

        void DestroyAll();
    }
}
