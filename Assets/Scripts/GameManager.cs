using Unity.VisualScripting;
using UnityEngine;

namespace ColoRunner
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [SerializeField] UICanvas uiCanvas;
        [SerializeField] AutoRunner autoRunner;

        private float timer = 0;
        private int seconds = 0;

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        void Update()
        {
            timer += Time.deltaTime;
            var s = (int)(timer%60);
            if (s > seconds)
            {
                seconds = s;
                uiCanvas.UpdateTimer(seconds);
            }
        }

        public void SetPlayerColor(RunnerColors color)
        {
            autoRunner.SetColor(color);
        }
    }
}