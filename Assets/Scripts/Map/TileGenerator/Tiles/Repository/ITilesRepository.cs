using UnityEngine;

namespace ProceduralWorld.Map.Tiles.Repository
{
    public interface ITilesRepository
    {
        /// <summary>
        /// Берем из хранилища точку
        /// </summary>
        ITile GetTile(Vector2Int _position);
    }
}