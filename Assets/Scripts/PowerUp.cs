using UnityEngine;

namespace ColoRunner
{
    public class PowerUp : MonoBehaviour
    {
        [SerializeField] RunnerColors color;

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