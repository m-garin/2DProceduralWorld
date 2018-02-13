using UnityEngine;

namespace ProceduralWorld.Map.Tiles
{
    public interface ITile
    {
        Vector2Int Position
        {
            get;
        }

        void ShowPrefab();

        void DestroyPrefab();
    }
}
