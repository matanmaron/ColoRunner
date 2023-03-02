using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using System;
using System.Linq;
using UnityEngine;

namespace ColoRunner
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        [SerializeField] UICanvas uiCanvas;
        [SerializeField] AutoRunner autoRunner;
        [SerializeField] PowerUp powerUpPrefab;
        [SerializeField] Transform powerUpParent;
        private float timer = 0;
        private int seconds = 0;
        private int perfectScore = 29;
        private bool isGameRunning = true;

        private void Awake()
        {
            if (instance == null)
                instance = this;
        }

        private void Start()
        {
            GenerateRandomPowerUp().Forget();
        }

        void Update()
        {
            if (isGameRunning)
            {
                timer += Time.deltaTime;
                var s = (int)(timer % 60);
                if (s > seconds)
                {
                    seconds = s;
                    uiCanvas.UpdateTimer(seconds);
                }
            }
        }

        public void SetPlayerColor(RunnerColors color)
        {
            autoRunner.SetColor(color);
        }

        public void HitFinishLine()
        {
            autoRunner.StopSpeed();
            isGameRunning = false;
            if (timer <= perfectScore)
            {
                uiCanvas.ShowScore(100);
            }
            else
            {
                float score = ((timer- perfectScore) * 100 / perfectScore);
                uiCanvas.ShowScore((int)(100 - score));
            }
        }

        private async UniTask GenerateRandomPowerUp()
        {
            while (isGameRunning)
            {
                float randTime = UnityEngine.Random.Range(0.05f, 1.5f);
                await UniTask.Delay(TimeSpan.FromSeconds(randTime));
                RunnerColors randPosition = (RunnerColors)UnityEngine.Random.Range(0, (int)Enum.GetValues(typeof(RunnerColors)).Cast<RunnerColors>().Max());
                ShowPowerUp(randPosition);
            }
        }

        private void ShowPowerUp(RunnerColors randPosition)
        {
            switch (randPosition)
            {
                case RunnerColors.Yellow:
                    InitPowerup(-3.3f);
                    break;
                case RunnerColors.Red:
                    InitPowerup(-0.7f);
                    break;
                case RunnerColors.Blue:
                    InitPowerup(1.9f);
                    break;
                case RunnerColors.Green:
                    InitPowerup(4.5f);
                    break;
                default:
                    Debug.LogError("No such color position");
                    break;
            }
        }

        private void InitPowerup(float x)
        {
            Vector3 runnerPos = autoRunner.transform.position;
            Vector3 pos = new Vector3(x, runnerPos.y, runnerPos.z + 60);
            PowerUp popup = Instantiate(powerUpPrefab, pos, Quaternion.identity, powerUpParent);
            popup.Init();
        }
    }
}