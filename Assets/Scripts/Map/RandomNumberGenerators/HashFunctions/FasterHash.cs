using UnityEngine;

namespace ProceduralWorld.RNG
{
    public class FasterHash : IHashFunction
    {
        uint key = 1;

        public int Range(Vector2Int _position, int range)
        {
            return (int)(GetHash(_position.x, _position.y) % range);
        }

        uint GetHash(int _x, int _y)
        {
            uint hashTmp = key;
            hashTmp ^= (uint)_x;
            hashTmp *= 0x51d7348d;
            hashTmp ^= 0x85dbdda2;
            hashTmp = (hashTmp << 16) ^ (hashTmp >> 16);
            hashTmp *= 0x7588f287;
            hashTmp ^= (uint)_y;
            hashTmp *= 0x487a5559;
            hashTmp ^= 0x64887219;
            hashTmp = (hashTmp << 16) ^ (hashTmp >> 16);
            hashTmp *= 0x63288691;
            return hashTmp;
        }
    }
}