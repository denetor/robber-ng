using UnityEngine;

// maintains information about the player status
public class PlayerController : MonoBehaviour
{
    [SerializeField] private int keys;
    [SerializeField] private int gems;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keys = 0;
        gems = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // add a key to the inventory
    public void AddKey() {
        keys++;
    }

    // add a gem to the inventory
    public void AddGem() {
        gems++;
    }
}
