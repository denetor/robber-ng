using UnityEngine;
using UnityEngine.Events;

public class AlarmSensorCollider : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            Debug.Log("Enter alarm zone");
            onTriggerEnter.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player")
        {
            onTriggerExit.Invoke();
        }
    }
}
