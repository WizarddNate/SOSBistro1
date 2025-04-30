using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    double timeInstantiated;

    //time that the note needs to be played by the player
    public float assignedTime;

    //note animation
    public Animator animator;

    void Start()
    {
        timeInstantiated = SongManager.GetAudioSourceTime();
    }

    void Update()
    {
        double timeSinceInstantiated = SongManager.GetAudioSourceTime() - timeInstantiated;
        float t = (float)(timeSinceInstantiated / (SongManager.Instance.noteTime * 2));
        t = Mathf.Clamp01(t);

        //Destroy note if the player misses and the note goes OFF SCREEN
        if (t >= 1)
        {
            Destroy(gameObject);
        }
        else
        {
            //animator.SetTrigger("Hit");
            transform.localPosition = Vector3.Lerp(Vector3.up * SongManager.Instance.noteSpawnY, Vector3.up * SongManager.Instance.noteDespawnY, t);
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void DestroyAnimation()
    {
        Debug.Log("Destroy Note");
        animator.SetTrigger("Hit");
    }

}
