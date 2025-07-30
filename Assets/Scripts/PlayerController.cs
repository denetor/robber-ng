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

}
