using System;
using UnityEngine;

public class GoldKeyCollectController : MonoBehaviour, ICollectable
{
    public static event Action<int> OnGoldKeyCollect;

    public string Collect() {
        // publish event
        OnGoldKeyCollect.Invoke(1);

        // destroy this item
        Destroy(gameObject);

        // return collected item id
        return "goldkey";
    }
}
