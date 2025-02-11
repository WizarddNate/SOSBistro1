using Melanchall.DryWetMidi.Interaction;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    //restricts notes to a certain key
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;

    //key input for this specific lane
    public KeyCode input;

    //prefab of the note to be spawned it
    public GameObject notePrefab;

    //manage prefabs
    List<Note> notes = new List<Note>();

    //list for when the player needs to give an input
    List<double> timestamps = new List<double>();

    //just helps keep track of things
    int spawnIndex = 0;
    int inputIndex = 0;


    public void SetTimestamps(Melanchall.DryWetMidi.Interaction.Note[] notesArray)
    {
        foreach (var note in notesArray)
        {
            if (note.NoteName == noteRestriction)
            {
                //return midi time into metric time (and then add it to our list?)
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap());
                timestamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f);
            }
        }
    }
    void Update()
    {
        //make this check for as long as the song is playing
        if (spawnIndex < timestamps.Count)
        {
            //checking to see if it's time for a note to spawn
            if (SongManager.GetAudioSourceTime() >= timestamps[spawnIndex] - SongManager.Instance.noteTime)
            {
                //create note
                var note = Instantiate(notePrefab, transform);
                notes.Add(note.GetComponent<Note>());

                //assign tap time to note
                note.GetComponent<Note>().assignedTime = (float)timestamps[spawnIndex];
                spawnIndex++;
            }
        }

        //inputs
        if (inputIndex < timestamps.Count)
        {
            //variables to simplify code 
            double timestamp = timestamps[inputIndex];
            double marginOfError = SongManager.Instance.magrinOfError;
            double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 1000.0);

            //check if player hit the note
            if (Input.GetKeyDown(input))
            {
                //check if player hit within margin of error
                if (Math.Abs(audioTime - timestamp) > marginOfError)
                {
                    //hit that note!!!
                    Hit();
                    //destory note
                    Destroy(notes[inputIndex].gameObject);
                    inputIndex++;
                }
                else
                {
                    Debug.Log($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timestamp)} delay");
                }
            }
            if (timestamp + marginOfError <= audioTime)
            {
                Miss();
                inputIndex++;
            }
        }
    }

    private void Hit()
    {
        Debug.Log($"Hit on {inputIndex} note");
        ScoreManager.Hit();
    }

    private void Miss()
    {
        Debug.Log("Missed {inputIndex} note");
        ScoreManager.Miss();
    }

}
