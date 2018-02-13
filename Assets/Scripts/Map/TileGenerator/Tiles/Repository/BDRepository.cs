using UnityEngine;

namespace ProceduralWorld.Map.Tiles.Repository
{
    /// <summary>
    /// Класс BDRepository
    /// Берет тайлы из БД
    /// </summary>
    public class BDRepository : ITilesRepository
    {
        public BDRepository()
        {
            //тут идет коннект к БД
        }

        public ITile GetTile(Vector2Int _position)
        {
            //Тут запрос к БД
            return null;
        }
    }
}