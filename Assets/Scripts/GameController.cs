using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField, Tooltip("Nr of keys collected")] private int keys;
    [SerializeField, Tooltip("Nr of gems collected")] private int gems;
    [SerializeField] private Text gemsIndicator;
    [SerializeField] private Text keysIndicator;
    private GameStatus gameStatus;
    private Button gameStartButton;
    private Text gameOverText;
    private Text levelCompleteText;
    private Text levelCompleteReasonText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameStartButton = GameObject.Find("StartButton").GetComponent<Button>();
        gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        levelCompleteText = GameObject.Find("LevelCompleteText").GetComponent<Text>();
        levelCompleteReasonText = GameObject.Find("LevelCompleteReasonText").GetComponent<Text>();
        if (gameOverText == null || levelCompleteText == null || levelCompleteReasonText == null)
        {
            Debug.LogError("One or more UI Text components are not assigned in the GameController.");
            return;
        }
        SetGameStatus(GameStatus.NotStarted);

        GemCollectController.GemCollectEvent.AddListener(AddGem);
        GoldKeyCollectController.GoldKeyCollectEvent.AddListener(AddKey);
    }



    public void StartGame()
    {
        if (gameStatus == GameStatus.NotStarted || gameStatus == GameStatus.Completed || gameStatus == GameStatus.Failed)
        {
            SetGameStatus(GameStatus.InProgress);
        }
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


    private void SetGameStatus(GameStatus newStatus)
    {
        gameStatus = newStatus;
        Debug.Log("Game status set to: " + gameStatus);
        switch (gameStatus)
        {
            case GameStatus.NotStarted:
                keys = 0;
                gems = 0;
                gemsIndicator.text = "Gems: 0";
                keysIndicator.text = "Keys: 0";
                gameStartButton.gameObject.SetActive(true);
                gameOverText.gameObject.SetActive(false);
                levelCompleteText.gameObject.SetActive(false);
                levelCompleteReasonText.gameObject.SetActive(false);
                break;
            case GameStatus.InProgress:
                gameStartButton.gameObject.SetActive(false);
                gameOverText.gameObject.SetActive(false);
                levelCompleteText.gameObject.SetActive(false);
                levelCompleteReasonText.gameObject.SetActive(false);
                break;
            case GameStatus.Paused:
                // Handle paused state
                break;
            case GameStatus.Completed:
                gameStartButton.gameObject.SetActive(true);
                gameOverText.gameObject.SetActive(false);
                levelCompleteText.gameObject.SetActive(true);
                levelCompleteReasonText.gameObject.SetActive(false);
                break;
            case GameStatus.Failed:
                gameStartButton.gameObject.SetActive(true);
                gameOverText.gameObject.SetActive(true);
                levelCompleteText.gameObject.SetActive(false);
                levelCompleteReasonText.gameObject.SetActive(true);
                break;
            default:
                // ignore errors
                break;
        }
    }


}

