using UnityEngine;

namespace MaronByteStudio.ColoRunner
{
    public class FinishLine : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log($"FinishLine Hit");
                GameManager.Instance.HitFinishLine();
                Destroy(gameObject);
            }
        }
    }
}
