using ProceduralWorld.Character;
using UnityEngine;
using UnityEngine.UI;

namespace ProceduralWorld.UI.DebugInfo
{
    public class PlayerDebugInfo : MonoBehaviour
    {
        [SerializeField]
        Player player;
        [SerializeField]
        Text textLinePosition;

        private void Update()
        {
            textLinePosition.text = "Player position " + player.Position.ToString();
        }
    }
}
