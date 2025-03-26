using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject ScoreManager;
    [SerializeField] GameObject GameOverPopup;

    //bool isPaused = false;

    public void Update()
    {
        //pause the game upon hitting escape
        if (Input.GetKey(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("LevelSelection");
    }
    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOver()
    {
        ScoreManager.SetActive(false);
        GameOverPopup.SetActive(true);
    }

    public void NextLevel()
    {
        Debug.Log("Next Level"); //CREATE FUNCTION
    }
}
