using UnityEngine;

namespace ProceduralWorld.UI.DebugInfo
{
    public class FPSDisplay : MonoBehaviour
    {

        public UnityEngine.UI.Text fpsText;

        public float updateInterval = 0.5F;
        private double lastInterval;
        private int frames = 0;
        private int fps;
        void Start()
        {
            lastInterval = Time.realtimeSinceStartup;
            frames = 0;
        }

        void Update()
        {
            ++frames;
            float timeNow = Time.realtimeSinceStartup;
            if (timeNow > lastInterval + updateInterval)
            {
                fps = (int)(frames / (timeNow - lastInterval));
                fpsText.text = fps.ToString();
                Color color = (fps >= 30) ? Color.green : ((fps > 10) ? Color.yellow : Color.red);
                fpsText.color = color;
                frames = 0;
                lastInterval = timeNow;
            }
        }
    }
}
