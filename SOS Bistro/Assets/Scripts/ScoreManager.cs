using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;
    public AudioSource missSFX;

    private Lane lane;

    //points score
    static int score;
    public TMP_Text scoreText;

    //hit streak, how many notes you've hit in a row without missing
    static int hitStreak;
    public TMP_Text streakText;

    //combo multiplier
    static int comboMultiplier;
    public TMP_Text comboText;

    //score accuracy (found in lane)
    [SerializeField]
    Lane[] lanes;
    private string _accuracy;

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
        if (hitStreak == 2)
        {
            comboMultiplier = 2;
        }
        if (hitStreak == 9)
        {
            comboMultiplier = 3;
        }
        if (hitStreak == 16)
        {
            comboMultiplier = 4;
        }

        //update text
        scoreText.text = ("Score: " + score.ToString());
        streakText.text = ("Hit Streak: " + hitStreak.ToString());
        comboText.text = ("Combo Score: X " + comboMultiplier.ToString());
    }

    public void Hit()
    {
        hitStreak += 1;

        for (int i = 0; i < lanes.Length; i++)
        {
            _accuracy = lanes[i].accuracy;
            Debug.Log(_accuracy);

            switch (_accuracy) 
            {
                case "Perfect!":
                    score = score + (10 *comboMultiplier);
                    break;

                case "Good!":
                    score = score + (8 * comboMultiplier);
                    break;

                case "OK!":
                    score = score + (4 * comboMultiplier);
                    break;

                case "Barely!" :
                    score = score + (2 * comboMultiplier);
                    break;

                default:
                    score = score + (0 * comboMultiplier);
                    break;

            }
        }
    }

    public void Miss()
    {
        hitStreak = 0;
        Instance.missSFX.Play();
    }



}
