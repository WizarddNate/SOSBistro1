using UnityEngine;
using UnityEngine.Audio;

public class SongTimer : MonoBehaviour
    
{
    public AudioSource audioSource;
    float songTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        songTime = audioSource.clip.length;
        Debug.Log("Audio clip length : " + songTime);
    }

    // Update is called once per frame
    void Update()
    {
        songTime -= Time.deltaTime;

        if (songTime <= 0 )
        {
            Debug.Log("Song over!!!!!");
        }
    }

    //get audio length
    //make a timer counting down from song length IN SECONDS
    //when timer is up, display win screen menu! Easy peasy ^_^
}
