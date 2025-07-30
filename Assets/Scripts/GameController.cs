using System;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{
    [SerializeField] private int keys;
    [SerializeField] private int gems;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keys = 0;
        gems = 0;

        GemCollectController.GemCollectEvent.AddListener(AddGem);
        GoldKeyCollectController.GoldKeyCollectEvent.AddListener(AddKey);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    // add a key to the inventory
    void AddKey() {
        Debug.Log("Key collected");
        keys ++;
    }

    // add a gem to the inventory
    public void AddGem() {
        Debug.Log("Gem collected");
        gems++;
    }
}
