using UnityEngine;

namespace ProceduralWorld.Map.Tiles
{
    public class Leaves : AbstractTile
    {
        public Leaves(Vector2Int _position): base(_position)
        {
            SetPrefabName = "Leaves";
        }
    }
}