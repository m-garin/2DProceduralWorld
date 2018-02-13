using System;
using UnityEngine;

namespace ProceduralWorld.Character.Boundary
{
    public interface IBoundaryController
    {
        RectInt Boundary { get; }

        void SetBoundaryCenter(Vector2Int _center);

        int GetSize { get; }

        event Action<RectInt> ChangedEvent;
    }
}