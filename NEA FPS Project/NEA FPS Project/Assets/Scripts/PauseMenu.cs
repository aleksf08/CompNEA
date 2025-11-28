using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenuUI;
    public bool gamePaused = false;


    public void Start()
    {
        //Ensure pause menu is closed at start
        pauseMenuUI.SetActive(false);

        //Lock and hide cursor at start
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused == true)
            {
                //Escapes pause menu if currently open
                Resume();
            }
            else
            {
                //Opens pause menu
                Pause();
            }
        }
    }


    //Resumes game from pause menu
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Resume game time
        gamePaused = false;

        //Lock and hide cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    //Pauses game and opens pause menu
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Pause game time
        gamePaused = true;

        //Unlock and show cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    //Loads main menu scene
    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Ensure game time is normal when loading main menu
        SceneManager.LoadScene("Main Menu");
    }

    //Loads settings menu scene
    public void LoadSettingsMenu()
    {
        Time.timeScale = 1f; // Ensure game time is normal when loading settings menu
        //SceneManager.LoadScene("Settings Menu");
        Debug.Log("Loading settings menu"); // Placeholder as settings menu hasn't been made yet
    }

    //Loads tutorial scene
    public void LoadTutorial()
    {
        Time.timeScale = 1f; // Ensure game time is normal when loading tutorial
        //SceneManager.LoadScene("Tutorial");
        Debug.Log("Loading tutorial"); // Placeholder as tutorial hasn't been made yet
    }


    




}
