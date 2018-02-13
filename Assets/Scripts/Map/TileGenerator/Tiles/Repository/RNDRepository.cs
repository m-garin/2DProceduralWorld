using ProceduralWorld.RNG;
using UnityEngine;

namespace ProceduralWorld.Map.Tiles.Repository
{
    /// <summary>
    /// Класс RNDRepository
    /// Генерирует тайлы с помощью хешфункций
    /// </summary>
    public class RNDRepository : ITilesRepository
    {
        enum TileTypeChance { Gold = 85, Dirt = 65, Leaves = 48, Sand = 40 };
        IHashFunction tileProbabilityRND;

        public RNDRepository(IHashFunction _RND)
        {
            tileProbabilityRND = new PerlinNoise();
        }

        public ITile GetTile(Vector2Int _position)
        {
            int chance = tileProbabilityRND.Range(_position, 100);
            if (chance >= (int)TileTypeChance.Gold)
            {
                return new Gold(_position);
            }
            else if (chance >= (int)TileTypeChance.Dirt)
            {
                return new Dirt(_position);
            }
            else if (chance >= (int)TileTypeChance.Leaves)
            {
                return new Leaves(_position);
            }
            else if (chance >= (int)TileTypeChance.Sand )
            {
                return new Sand(_position);
            }
            else
            {
                return new Water(_position);
            }
        }
    }
}