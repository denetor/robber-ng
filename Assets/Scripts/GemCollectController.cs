using System;
using UnityEngine;
using UnityEngine.Events;

public class GemCollectController : MonoBehaviour, ICollectable
{
    public static UnityEvent GemCollectEvent;

    void Start() {
        if (GemCollectEvent == null) {
            GemCollectEvent = new UnityEvent();
        }
    }

    public void Collect() {
        // publish event
        GemCollectEvent.Invoke();
        Debug.Log("Invoked GemCollectEvent");

        // destroy this item
        Destroy(gameObject);
    }
}
