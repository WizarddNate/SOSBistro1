using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LevelSelection : MonoBehaviour
{
    //THIS CODE SHOULD WORK LIKE A CHARM BUT HAS YET TO BE TESTED. USE WITH AWARENESS.

    //manually put in the level number 
    public int level;
    
    //this should be the same as your level number seen above ^^
    public TMP_Text levelText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        levelText.text = level.ToString();
    }

    // Update is called once per frame
    public void LoadScene()
    {
        SceneManager.LoadScene("Level" + level.ToString());
        
    }
}
