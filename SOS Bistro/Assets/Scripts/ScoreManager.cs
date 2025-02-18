using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;
    public AudioSource missSFX;

    //points score
    static int score;
    public TMP_Text scoreText;

    //hit streak, how many notes you've hit in a row without missing
    static int hitStreak;
    public TMP_Text streakText;

    //combo multiplier
    static int comboMultiplier;
    public TMP_Text comboText;


    void Start()
    {
        //instanciate scoremanager on start
        Instance = this;
        score = 0;
        hitStreak = 0;
        comboMultiplier = 1;
    }
    private void Update()
    {
        //score multiplier increases as hit streak does
        if (hitStreak == 0)
        {
            comboMultiplier = 0;
        }
        if (hitStreak == 3)
        {
            comboMultiplier = 2;
        }
        if (hitStreak == 6)
        {
            comboMultiplier = 3;
        }
        if (hitStreak == 9)
        {
            comboMultiplier = 4;
        }

        //update text
        scoreText.text = score.ToString();
        streakText.text = hitStreak.ToString();
        comboText.text = comboMultiplier.ToString();
    }

    public static void Hit()
    {
        hitStreak += 1;
        score = score + (10 * comboMultiplier);
    }

    public static void Miss()
    {
        hitStreak = 0;
        Instance.missSFX.Play();
    }



}
