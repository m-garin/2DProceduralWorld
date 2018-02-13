using UnityEngine;

namespace ProceduralWorld.Map.Tiles
{
    public class Gold : AbstractTile
    {
        public Gold (Vector2Int _position): base(_position)
        {
            SetPrefabName = "Gold";
        }
    }
}