using ProceduralWorld.Character;
using ProceduralWorld.Character.Boundary;
using SpaceExplorer.CameraView;
using System;
using UnityEngine;

namespace ProceduralWorld.Ship.Boundary
{
    /// <summary>
    ///  Контроль границ видимости
    /// </summary>
    public class CameraBoundaryController : IBoundaryController
    {
        RectInt boundary;
        ICamera camera;
        readonly MovableObject2D player;

        public CameraBoundaryController(MovableObject2D _player, ICamera _camera)
        {
            player = _player;
            camera = _camera;
            boundary = camera.GetViewBoundary;

            player.MovedObject += SetBoundaryCenter;
            SetBoundaryCenter(player.Position);
        }

        public RectInt Boundary
        {
            get
            {
                return boundary;
            }
        }

        public int GetSize
        {
            get
            {
                return (boundary.width + 1) * (boundary.height + 1);
            }
        }

        public void SetBoundaryCenter(Vector2Int _center)
        {
            boundary.position = new Vector2Int(_center.x - boundary.width / 2, _center.y - boundary.height / 2);
            ChangedEvent?.Invoke(boundary);
        }

        public event Action<RectInt> ChangedEvent;
    }
}