using UnityEngine;
using System.Collections.Generic;
using ProceduralWorld.Map.Tiles.Display;
using ProceduralWorld.Map.Tiles.Repository;

namespace ProceduralWorld.Map.Tiles
{
    /// <summary>
    /// Класс TileGenerator
    /// Получает тайлы из репозитория и передает дальше для вывода
    /// </summary>
    public class TileGenerator
    {
        readonly Dictionary<string, ITile> tiles;
        readonly ITilesRepository tilesRepository;
        IDisplayMode<ITile> displayMode; //тут производится отбор
        public IDisplayMode<ITile> SetTilesViewer
        {
            set
            {
                displayMode = value;
            }
        }

        Dictionary<string, ITile> TopTiles { get; set; }

        public TileGenerator(ITilesRepository _tilesRepository)
        {
            tiles = new Dictionary<string, ITile>(); //можно переделать на пробрасывание
            tilesRepository = _tilesRepository;
        }

        public void Generate(Vector2Int _position)
        {
            displayMode.CheckIn(tilesRepository.GetTile(_position));
        }

        public void Remove(Vector2Int _position)
        {
            displayMode.CheckOut(_position);
        }
    }
}
