using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace ColoRunner
{
    public class FinishLine : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                Debug.Log($"FinishLine Hit");
                GameManager.instance.HitFinishLine();
                Destroy(gameObject);
            }
        }
    }
}
