using UnityEngine;

namespace ProceduralWorld.Ship.Controller
{
    public class MobileInput : MonoBehaviour, IInputDevice2D
    {
        Vector2Int move = Vector2Int.zero;

        public void MoveButtonPressed(int _value)
        {
            switch (_value)
            {
                case 0: //up
                    move = Vector2Int.up;
                    break;
                case 1: //right
                    move = Vector2Int.right;
                    break;
                case 2:
                    move = Vector2Int.down;
                    break;
                case 3:
                    move = Vector2Int.left;
                    break;
                default:
                    move = Vector2Int.zero;
                    break;
            }
        }

        public Vector2Int GetMove
        {
            get
            {
                return move;
            }
        }

        private void Start()
        {
#if UNITY_EDITOR || !(UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE)
            gameObject.SetActive(false);
#endif
        }
    }
}