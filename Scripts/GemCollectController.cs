using UnityEngine;

public class GemCollectController : MonoBehaviour, ICollectable
{
    public string Collect() {
        // destroy this item
        Destroy(gameObject);

        // return collected item id
        return "gem";
    }
}
