using UnityEngine;

namespace ProceduralWorld.Map.Tiles
{
    public class Sand : AbstractTile
    {
        public Sand(Vector2Int _position): base(_position)
        {
            SetPrefabName = "Sand";
        }
    }
}