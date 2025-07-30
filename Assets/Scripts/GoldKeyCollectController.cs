using System;
using UnityEngine;
using UnityEngine.Events;

public class GoldKeyCollectController : MonoBehaviour, ICollectable
{
    public static UnityEvent GoldKeyCollectEvent;

    void Start() {
        if (GoldKeyCollectEvent == null) {
            GoldKeyCollectEvent = new UnityEvent();
        }
    }

    public void Collect() {
        // publish event
        GoldKeyCollectEvent.Invoke();

        // destroy this item
        Destroy(gameObject);
    }
}
