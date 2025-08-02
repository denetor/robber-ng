using UnityEngine;
using UnityEngine.Events;

public class AlarmTripwireCollider : MonoBehaviour
{
    [SerializeField] UnityEvent onTriggerEnter;
    [SerializeField] UnityEvent onTriggerExit;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            Debug.Log("Alarm tripwire triggered");
            onTriggerEnter.Invoke();
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        onTriggerExit.Invoke();
    }
}
