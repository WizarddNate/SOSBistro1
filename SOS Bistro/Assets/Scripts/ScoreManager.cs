using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;
    public AudioSource hitSFX;
    public AudioSource missSFX;

    //display score. This doesnt work for some reason
    public TMPro.TextMeshPro scoreText;

    static int comboScore;


    void Start()
    {
        //instancisate scoremanager on start
        Instance = this;
        comboScore = 0;
    }

    public static void Hit()
    {
        comboScore += 1;
        Instance.hitSFX.Play();
    }

    public static void Miss()
    {
        comboScore = 0;
        Instance.missSFX.Play();
    }

    private void Update()
    {
        //scoreText.text = comboScore.ToString();
    }

}
