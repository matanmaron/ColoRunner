using System;
using System.Linq;
using UnityEngine;

namespace ColoRunner
{
    public class PowerUp : MonoBehaviour
    {
        [SerializeField] Material redColor;
        [SerializeField] Material blueColor;
        [SerializeField] Material greenColor;
        [SerializeField] Material yellowColor;

        private MeshRenderer m_MeshRenderer;
        private RunnerColors color;

        public void Init()
        {
            m_MeshRenderer = GetComponent<MeshRenderer>();
            if (m_MeshRenderer == null)
            {
                Debug.LogError("CANNOT FIND playerObject MeshRenderer");
            }
            color = (RunnerColors)UnityEngine.Random.Range(0, (int)Enum.GetValues(typeof(RunnerColors)).Cast<RunnerColors>().Max());
            switch (color)
            {
                case RunnerColors.Red: m_MeshRenderer.materials = new Material[1] { redColor }; break;
                case RunnerColors.Blue: m_MeshRenderer.materials = new Material[1] { blueColor }; break;
                case RunnerColors.Green: m_MeshRenderer.materials = new Material[1] { greenColor }; break;
                case RunnerColors.Yellow: m_MeshRenderer.materials = new Material[1] { yellowColor }; break;
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log($"{gameObject.name} {color} collected");
                GameManager.instance.SetPlayerColor(color);
                Destroy(gameObject);
            }
        }
    }
}