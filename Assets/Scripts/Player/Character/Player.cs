using ProceduralWorld.Ship.Controller;
using SpaceExplorer.CameraView;
using UnityEngine;

namespace ProceduralWorld.Character
{
    public class Player : MovableObject2D
    {
        [SerializeField]
        CameraController cameraController;
        IInputDevice2D inputDevice;

        private void Start()
        {
            inputDevice = new PCInput();
        }

        void Update()
        {
            Vector2Int moveVector = inputDevice.GetMove;

            if (moveVector != Vector2Int.zero)
                Move(moveVector);
        }
    }
}