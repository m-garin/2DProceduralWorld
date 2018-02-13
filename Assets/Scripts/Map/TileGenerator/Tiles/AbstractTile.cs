using QuickPool;
using UnityEngine;

namespace ProceduralWorld.Map.Tiles
{
    /// <summary>
    /// Класс AbstractTile
    /// Реализация абстрактного класса тайла, от него будут наследоваться конкретные реализации
    /// </summary>
    public class AbstractTile : ITile
    {
        readonly Vector2Int position;
        public Vector2Int Position
        {
            get
            {
                return position;
            }
        }

        GameObject prefab;
        string prefabName;

        public AbstractTile(Vector2Int _position)
        {
            position = _position;
        }

        /// <summary>
        /// Спауним префаб
        /// </summary>
        public void ShowPrefab()
        {
            if (prefab == null)
            {
                prefab = PoolsManager.Spawn(prefabName, new Vector3(position.x, position.y, 0), Quaternion.identity);
                prefab.transform.SetParent(GameObject.FindGameObjectWithTag("MapLayer").transform);//инкапсулировать
            }
        }

        protected string SetPrefabName
        {
            set
            {
                prefabName = value;
            }
        }

        public void DestroyPrefab()
        {
            if (prefab != null)
            {
                prefab.Despawn();
                prefab = null;
            }
        }
    }
}