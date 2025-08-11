using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField, Tooltip("Nr of keys collected")] private int keys;
    [SerializeField, Tooltip("Nr of gems collected")] private int gems;
    [SerializeField, Tooltip("Current air percentage before drowning")] private float air;
    [SerializeField] private Text gemsIndicator;
    [SerializeField] private Text keysIndicator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keys = 0;
        gems = 0;
        air = 100f;
        gemsIndicator.text = "Gems: 0";
        keysIndicator.text = "Keys: 0";

        GemCollectController.GemCollectEvent.AddListener(AddGem);
        GoldKeyCollectController.GoldKeyCollectEvent.AddListener(AddKey);
    }


    // add a key to the inventory
    void AddKey()
    {
        keys++;
        keysIndicator.text = "Keys: " + keys;
    }

    // add a gem to the inventory
    public void AddGem()
    {
        gems++;
        gemsIndicator.text = "Gems: " + gems;
    }

    public float getAir()
    {
        return air;
    }

    public void setAir(float value)
    {
        air = Mathf.Clamp(value, 0f, 100f);
        if (air <= 0f)
        {
            // Handle drowning logic here
            Debug.Log("Player has drowned!");
            // You might want to reset the game or show a game over screen
        }
    }

}

