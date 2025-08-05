using UnityEngine;

public class WaterColliderController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other) {
        //if (other.tag == "Player")
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enter water");
            other.GetComponent<PlayerMovement>().setSwimming(true);
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Exit from water");
            other.GetComponent<PlayerMovement>().setSwimming(false);
        }
    }
}
