using System;
using UnityEngine;

namespace ProceduralWorld.Character
{ 
    /// <summary>
    ///  Класс MovableObject2D
    ///  Управление 2D персонажем
    /// </summary>
    public class MovableObject2D : MonoBehaviour
    {
        public event Action<Vector2Int> MovedObject;

        public Vector2Int Position
        {
            get
            {
                return new Vector2Int((int)transform.position.x, (int)transform.position.y);
            }
            protected set
            {
                transform.position = new Vector3(value.x, value.y, transform.position.z);
            }
        }

        protected void Move(Vector2Int _delta)
        {
            Position += _delta;
            this.transform.rotation = Quaternion.LookRotation(Vector3.forward, new Vector2(_delta.x, _delta.y));

            MovedObject?.Invoke(Position);
        }
    }
}