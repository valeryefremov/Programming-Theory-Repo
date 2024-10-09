using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // ENCAPSULATION
    public bool IsGameOver { get; private set; }

    // ABSTRACTION
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text messageText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;

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

    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void MenuScene()
    {
        SceneManager.LoadScene(0);
    }
}
