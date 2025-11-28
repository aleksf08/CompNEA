using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    //When Start is clicked
    public void PlayGame()
    {
        SceneManager.LoadScene("Arena Scene");
    }

    //When Tutorial is clicked
    public void LoadTutorial()
    {
        Debug.Log("Loading tutorial"); //placeholder as tutorial hasn't been made yet
    }

    //When Settings is clicked
    public void LoadSettings()
    {
        Debug.Log("Loading settings"); //placeholder as settings haven't been made yet
    }

    //When Exit is clicked
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit"); //placeholder as application.quit doesnt work in editor
    }





}