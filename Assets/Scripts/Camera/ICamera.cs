using UnityEngine;

namespace SpaceExplorer.CameraView
{
    public interface ICamera
    {
        RectInt GetViewBoundary
        {
            get;
        }
    }
}