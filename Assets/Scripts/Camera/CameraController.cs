using ProceduralWorld.Character.Boundary;
using UnityEngine;

namespace SpaceExplorer.CameraView
{
    public class CameraController : MonoBehaviour, ICamera
    {
        Camera mainCamera;
        IBoundaryController boundaryController;
        float relativeSize = 1.0f;

        void Start()
        {
            mainCamera = Camera.main;
        }

        public IBoundaryController SetBoundaryController
        {
            set
            {
                boundaryController = value;
            }
        }

        void LateUpdate()
        {
            if (boundaryController != null)
            {
                RectInt boundary = boundaryController.Boundary;
                transform.position = new Vector3(boundary.center.x, boundary.center.y, transform.position.z);
            }
        }

        /// <summary>
        /// ¬ычисл€ет границы, которые видны в камеру
        /// </summary>
        public RectInt GetViewBoundary
        {
            get
            {
                Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0));
                //var bottomRight = camera.ViewportToWorldPoint(new Vector3(1, 0, 0));
                Vector3 topLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 1, 0));
                Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));
                int x1 = Mathf.RoundToInt(topLeft.x);
                int y1 = Mathf.RoundToInt(bottomLeft.y);
                int x2 = Mathf.RoundToInt(topRight.x);
                int y2 = Mathf.RoundToInt(topRight.y);
                return new RectInt(x1, y1, x2 - x1, y2 - y1);
            }
        }
    }
}
