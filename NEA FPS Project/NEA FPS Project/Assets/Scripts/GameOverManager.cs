using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{

    public GameObject gameOverUI;
    public bool isGameOver = false;
    
    public Text waveText;
    public Text killsText;

    public WaveManager waveManager;
   
    void Start()
    {
        isGameOver = false;
        gameOverUI.SetActive(false);
    }

    public void TriggerGameOver()
    {
        isGameOver = true;
        gameOverUI.SetActive(true);

        Time.timeScale = 0f; // Pause the game

        //unlock and show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        //Display stats
        waveText.text = "You survived to wave " + waveManager.currentWave + "!";
        killsText.text = "You killed " + waveManager.enemiesKilled + " enemies!";
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene("Arena Scene");
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Resume the game
        SceneManager.LoadScene("Main Menu");
    }
}
