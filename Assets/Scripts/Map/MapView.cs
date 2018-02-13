using ProceduralWorld.Character;
using ProceduralWorld.Character.Boundary;
using ProceduralWorld.Ship.Boundary;
using ProceduralWorld.UI.DebugInfo;
using SpaceExplorer.CameraView;
using UnityEngine;

namespace ProceduralWorld.Map
{
    /// <summary>
    ///  Класс MapView
    ///  Управляет отображением карты
    /// </summary>
    sealed public class MapView : MonoBehaviour
    {
        [SerializeField]
        Player playerController;
        [SerializeField]
        CameraController cameraController;
        [SerializeField]
        MapDebugInfo mapDebug;

        IBoundaryController boundaryController;

        DrawMap drawMap;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        private void Start()
        {
            boundaryController = new CameraBoundaryController(playerController, cameraController);
            cameraController.SetBoundaryController = boundaryController;
            mapDebug.SetBoundaryController = boundaryController;

            drawMap = new DrawMap();
            drawMap.Redraw(boundaryController.Boundary); //отрисуем первый раз
            boundaryController.ChangedEvent += drawMap.Redraw; //отрисуем, если границы видимости изменились (сместились/изменился размер)
        }

        private void OnDestroy()
        {
            boundaryController.ChangedEvent -= drawMap.Redraw;
        }
    }
}