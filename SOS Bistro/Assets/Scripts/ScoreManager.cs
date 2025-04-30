using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;
    public AudioSource missSFX;

    private Lane lane;

    //points score
    public int score { get; private set; }
    public TMP_Text scoreText;

    //hit streak, how many notes you've hit in a row without missing
    public int hitStreak { get; private set; }
    public TMP_Text streakText;
    public int longestHitStreak { get; private set; }

    //how many numbers hit in total
    public int numOfHits { get; private set; }

    //combo multiplier
    public int comboMultiplier { get; private set; }
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
        if (hitStreak == 12)
        {
            comboMultiplier = 2;
        }
        if (hitStreak == 16)
        {
            comboMultiplier = 3;
        }
        if (hitStreak == 20)
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

        if (hitStreak > longestHitStreak)
        {
            longestHitStreak = hitStreak;
        }

        numOfHits += 1;

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
