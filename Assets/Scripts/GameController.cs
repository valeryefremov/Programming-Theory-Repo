using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool IsGameOver { get; private set; }

    [SerializeField] GameObject gameOverScreen;
    [SerializeField] Text messageText;
    [SerializeField] Button restartButton;
    [SerializeField] Button menuButton;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartScene);
        menuButton.onClick.AddListener(MenuScene);
        gameOverScreen.SetActive(false);
    }

    public void GameOver(bool isPlayerWin)
    {
        IsGameOver = true;
        gameOverScreen.SetActive(true);

        if (isPlayerWin)
        {
            messageText.text = "You Win !!!";
            messageText.color = Color.green;
        }
        else
        {
            messageText.text = "You Loose !!!";
            messageText.color = Color.red;
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
