using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;

    //time that the note needs to be played by the player
    public float assignedTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();
    }

    // Update is called once per frame
    void Update()
    {
        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.noteTime * 2));

        if (t > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(Vector3.up * SongManager.Instance.noteSpawnY, Vector3.up * SongManager.Instance.noteDespawnY, t);
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
