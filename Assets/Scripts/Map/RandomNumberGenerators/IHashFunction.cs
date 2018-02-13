using UnityEngine;

namespace ProceduralWorld.RNG
{
    public interface IHashFunction
    {
        /// <summary>
        ///Returns the value between 0 [inclusive] and _range [exclusive]
        /// </summary>
        int Range(Vector2Int _position, int _range);
    }
}
