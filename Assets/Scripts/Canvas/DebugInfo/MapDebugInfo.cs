using ProceduralWorld.Character.Boundary;
using UnityEngine;
using UnityEngine.UI;

namespace ProceduralWorld.UI.DebugInfo
{
    public class MapDebugInfo : MonoBehaviour
    {
        [SerializeField]
        Text textLine;

        IBoundaryController boundaryController;

        public IBoundaryController SetBoundaryController
        {
            set
            {
                boundaryController = value;
            }
        }

        // Update is called once per frame
        void Update()
        {
            RectInt boundary = boundaryController.Boundary;

            int size = boundaryController.GetSize;
            int width = (int)Mathf.Sqrt(boundaryController.GetSize);
            textLine.text = "Space size: " + width + "x" + width + " (" + boundaryController.GetSize + " tiles)";
        }
    }
}
