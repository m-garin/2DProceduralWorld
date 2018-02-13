using UnityEngine;

namespace ProceduralWorld.Map.Tiles
{

    public class Water : AbstractTile
    {
        public Water (Vector2Int _position): base(_position)
        {
            SetPrefabName = "Water";
        }
    }
}