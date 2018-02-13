using UnityEngine;

namespace ProceduralWorld.Map.Tiles
{
    public class Dirt : AbstractTile
    {
        public Dirt(Vector2Int _position): base(_position)
        {
            SetPrefabName = "Dirt";
        }
    }
}