using UnityEngine;

// maintains information about the player status
public class PlayerController : MonoBehaviour
{
    GameController gc;

    void Awake() {
        gc = GetComponent<GameController>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // add a key to the inventory
    public void AddKey() {
        if (gc) {
            gc.AddKey();
        }
    }

    // add a gem to the inventory
    public void AddGem() {
        if (gc) {
            gc.AddGem();
        }
    }
}
