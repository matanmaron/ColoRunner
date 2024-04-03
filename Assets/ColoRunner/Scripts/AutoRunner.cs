using UnityEngine;

namespace MaronByteStudio.ColoRunner
{
    public class AutoRunner : MonoBehaviour
    {
        [SerializeField] Renderer PlayerRenderer;
        [SerializeField] Material PlayerMaterial;
        private Rigidbody m_Rigidbody;
        private float slowSpeed = 10.0f;
        private float boostSpeed = 40.0f;
        private float currentSpeed = 0f;
        private RunnerColors currentRunnerColor = RunnerColors.Red;
        private RunnerColors currentLaneColor = RunnerColors.Red;
        private LaneDirection nextLaneDirection = LaneDirection.None;
        bool holdingDown;

        void Start()
        {
            PlayerMaterial.color = Color.red;
            currentSpeed = slowSpeed;
            currentSpeed = boostSpeed;//REMOVE
            m_Rigidbody = GetComponent<Rigidbody>();
            if (m_Rigidbody == null)
            {
                Debug.LogError("CANNOT FIND playerObject Rigidbody");
            }
        }

        void Update()
        {
            m_Rigidbody.velocity = transform.forward * currentSpeed;
            if (!holdingDown)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    holdingDown = true;
                    nextLaneDirection = LaneDirection.Left;
                    Debug.Log("go left");
                    ChangeLane(nextLaneDirection);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    holdingDown = true;
                    nextLaneDirection = LaneDirection.Right;
                    Debug.Log("go right");
                    ChangeLane(nextLaneDirection);
                }
            }
            if (holdingDown)
            {
                if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    holdingDown = false;
                }
                if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {
                    holdingDown = false;
                }
            }
        }

        public void SetColor(RunnerColors color)
        {
            switch (color)
            {
                case RunnerColors.Red: PlayerMaterial.color = Color.red; break;
                case RunnerColors.Blue:PlayerMaterial.color = Color.blue; break;
                case RunnerColors.Green: PlayerMaterial.color = Color.green; break;
                case RunnerColors.Yellow: PlayerMaterial.color = Color.yellow; break;
            }
            PlayerRenderer.material = PlayerMaterial;
            currentRunnerColor = color;
            UpdateSpeed();
        }

        public void SetSpeed(bool isBoost)
        {
            currentSpeed = isBoost ? boostSpeed : slowSpeed;
        }

        public void StopSpeed()
        {
            currentSpeed = 0;
        }

        private void ChangeLane(LaneDirection direction)
        {
            switch (direction)
            {
                case LaneDirection.None:
                    return;
                case LaneDirection.Left:
                    MoveLeft();
                    break;
                case LaneDirection.Right:
                    MoveRight();
                    break;
                default:
                    Debug.LogError("Undefined lane direction");
                    break;
            }
        }

        private void MoveLeft()
        {
            if (currentLaneColor == RunnerColors.Yellow)
            {
                return;
            }
            Move(-1);
        }

        private void MoveRight()
        {
            if (currentLaneColor == RunnerColors.Green)
            {
                return;
            }
            Move(1);
        }

        private void Move(int direction)
        {
            Vector3 newPos = new Vector3(transform.position.x + (2.6f * direction), transform.position.y, transform.position.z);
            transform.SetPositionAndRotation(newPos, transform.rotation);
            currentLaneColor += (1 * direction);
            nextLaneDirection = LaneDirection.None;
            Debug.Log($"currentLaneColor is {currentLaneColor}");
            UpdateSpeed();
        }

        private void UpdateSpeed()
        {
            if (currentLaneColor == currentRunnerColor)
            {
                currentSpeed = boostSpeed;
            }
            else
            {
                currentSpeed = slowSpeed;
            }
        }
    }

    public enum RunnerColors
    {
        Yellow,
        Red,
        Blue,
        Green
    }

    public enum LaneDirection
    {
        None,
        Left,
        Right
    }
}