using UnityEngine;

namespace ColoRunner
{
    public class AutoRunner : MonoBehaviour
    {
        [SerializeField] Material redColor;
        [SerializeField] Material blueColor;
        [SerializeField] Material greenColor;
        [SerializeField] Material yellowColor;

        private Rigidbody m_Rigidbody;
        private MeshRenderer m_MeshRenderer;
        private float m_Speed = 10.0f;

        void Start()
        {
            m_Rigidbody = GetComponent<Rigidbody>();
            if (m_Rigidbody == null)
            {
                Debug.LogError("CANNOT FIND playerObject Rigidbody");
            }
            m_MeshRenderer = GetComponent<MeshRenderer>();
            if (m_MeshRenderer == null)
            {
                Debug.LogError("CANNOT FIND playerObject MeshRenderer");
            }
        }

        void Update()
        {
            m_Rigidbody.velocity = transform.forward * m_Speed;
        }

        public void SetColor(RunnerColors color)
        {
            switch (color)
            {
                case RunnerColors.Red: m_MeshRenderer.materials = new Material[1] { redColor }; break;
                case RunnerColors.Blue: m_MeshRenderer.materials = new Material[1] { blueColor }; break;
                case RunnerColors.Green: m_MeshRenderer.materials = new Material[1] { greenColor }; break;
                case RunnerColors.Yellow: m_MeshRenderer.materials = new Material[1] { yellowColor }; break;
            }
        }
    }

    public enum RunnerColors
    {
        Red,
        Blue,
        Green,
        Yellow
    }
}