using UnityEngine;

// controller to manage the collection of items
public class PlayerCollectController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        ICollectable item = collision.GetComponent<ICollectable>();
        PlayerController pc = GetComponent<PlayerController>();
        string collectedItemId;

        if (item != null) {
            collectedItemId = item.Collect();
            // Debug.Log(collectedItemId);

            // increment keys numbers
            if (pc != null && (collectedItemId == "goldkey" || collectedItemId == "bluekey")) {
                pc.AddKey();
            } else if (pc != null && collectedItemId == "gem") {
                pc.AddGem();
            }
        }
    }
}
