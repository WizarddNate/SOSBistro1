using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;

    public AudioSource hitSFX;
    public AudioSource missSFX;

    //display score
    //public TMPro.TextMeshPro scoreText;
    static int comboScore;


    void Start()
    {
        //instancisate scoremanager on start
        Instance = this;
        comboScore = 0;
    }

    public static void Hit()
    {
        Instance.hitSFX.Play();
        comboScore += 1;
    }

    public static void Miss()
    {
        Instance.missSFX.Play();
        comboScore = 0;
    }

    private void Update()
    {
        //scoreText.text = comboScore.ToString();
    }

}
