using UnityEngine;

namespace ProceduralWorld.RNG
{
    public class PerlinNoise : IHashFunction
    {
        float wavelenght = 12.0f;

        public int Range(Vector2Int _position, int _range)
        {
            return Mathf.Clamp((int)(Mathf.PerlinNoise(_position.x / wavelenght, _position.y / wavelenght) * (_range + 1)), 0, _range);
        }
    }
}