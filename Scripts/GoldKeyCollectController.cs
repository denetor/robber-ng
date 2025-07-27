using UnityEngine;

public class GoldKeyCollectController : MonoBehaviour, ICollectable
{
    public string Collect() {
        // destroy this item
        Destroy(gameObject);

        // return collected item id
        return "goldkey";
    }
}
