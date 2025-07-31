using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private int keys;
    [SerializeField] private int gems;
    [SerializeField] private Text gemsIndicator;
    [SerializeField] private Text keysIndicator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keys = 0;
        gems = 0;
        gemsIndicator.text = "Gems: 0";
        keysIndicator.text = "Keys: 0";

        GemCollectController.GemCollectEvent.AddListener(AddGem);
        GoldKeyCollectController.GoldKeyCollectEvent.AddListener(AddKey);
    }


    // add a key to the inventory
    void AddKey() {
        keys ++;
        keysIndicator.text = "Keys: " + keys;
    }

    // add a gem to the inventory
    public void AddGem() {
        gems++;
        gemsIndicator.text = "Gems: " + gems;
    }

}

