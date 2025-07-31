using UnityEngine;

// controller to manage the collection of items
public class PlayerCollectController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collidedObject) {
        PlayerController pc = GetComponent<PlayerController>();
        ICollectable item = collidedObject.GetComponent<ICollectable>();

        if (item != null) {
            item.Collect();
        }

        // if collided with exit, remove it
        if (collidedObject.gameObject.name == "LevelExitTile") {
            Debug.Log("You left this level");
            Destroy(collidedObject.gameObject);
        }
    }
}
