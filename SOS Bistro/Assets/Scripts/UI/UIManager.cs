using Melanchall.DryWetMidi.MusicTheory;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject ScoreManager;
    [SerializeField] GameObject GameOverPopup;


    //all stuff for the game over screen
    [SerializeField] ScoreManager scoreM;
    [SerializeField] SongManager songM;

    private string lvlGrade;
    public TMP_Text lvlGradeText;
    public TMP_Text lvlScore;
    public TMP_Text passOrFail;
    public TMP_Text notesHit;
    public TMP_Text longestStreak;
    public int level;

    //bool isPaused = false

    /// <summary>
    /// Button presses !! All of your button presses !!!!
    /// </summary>

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
        ScoreManager.SetActive(false);
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }
    public void Resume()
    {
        ScoreManager.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }

    public void MainMenu()
    {
        ScoreManager.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;

        SceneManager.LoadScene("MainMenu");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelection");
    }

    public void Restart()
    {
        ScoreManager.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;

        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }

    //this is for the settings of the main menu, it's NOT for the pause menu

    public void SettingsOpen()
    {
        Debug.Log("settings open!");
    }

    public void SettingsClose()
    {
        Debug.Log("settings closed!");
    }


    public void GameOver()
    {
        Debug.Log("GAME OVER !!!!!");
        ScoreManager.SetActive(false);
        GameOverPopup.SetActive(true);

        lvlScore.text = ("Score: " + scoreM.score);

        Debug.Log("Score: "+ scoreM.score +". Max score: " + songM.maxScore);

        //Determine Level Grade
        if (scoreM.score >= songM.maxScore)
        {
            lvlGrade = "S";
        }
        else if (scoreM.score >= (songM.maxScore * 0.8))
        {
            lvlGrade = "A";
        }
        else if (scoreM.score >= (songM.maxScore * 0.7))
        {
            lvlGrade = "B";
        }
        else if (scoreM.score >= (songM.maxScore * 0.6))
        {
            lvlGrade = "C";
        }
        else
        {
            lvlGrade = "F";
        }

        lvlGradeText.text = ("Grade: " + lvlGrade);


        //pass/failure
        if (lvlGrade == "S" || lvlGrade == "A" || lvlGrade == "B" || lvlGrade == "C")
        {
            passOrFail.text = "Success!!";
        }
        else
        {
            passOrFail.text = "Failure!!!";
        }

        //display the note hit to miss ratio
        notesHit.text = ("( " + scoreM.numOfHits + "/" + songM.maxNotes + " )");

        //display the level score
        lvlScore.text = (scoreM.score + " Points!");

        //longest winning streak
        longestStreak.text = ("Longest Streak: " + scoreM.longestHitStreak);


    }

    public void NextLevel()
    {
        level = level + 1;

        ScoreManager.SetActive(true);
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
        AudioListener.pause = false;

        if (level == 7)
        {
            SceneManager.LoadScene("Main Menu");
        }
        SceneManager.LoadScene("Level" + level.ToString());


    }
}
