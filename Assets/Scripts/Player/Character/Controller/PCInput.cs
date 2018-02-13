using UnityEngine;

namespace ProceduralWorld.Ship.Controller
{
    public class PCInput : IInputDevice2D
    {
        public Vector2Int GetMove
        {
            get
            {
                Vector2Int move = new Vector2Int((int)(Input.GetAxisRaw("Horizontal")), (int)(Input.GetAxisRaw("Vertical")));
                /*
                if (move.x != 0)
                {
                    move.y = 0;
                }*/

                return move;
            }
        }
    }
}