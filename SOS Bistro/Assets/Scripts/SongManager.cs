using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;

public class SongManager : MonoBehaviour
{

    public static SongManager Instance;
    public AudioSource audioSource;

    //array of lanes
    public Lane[] lanes;

    //delay our song after a certain time
    public float songDelayInSeconds;
    public int inputDelayInMilliseconds;

    //margin of error in seconds
    public double magrinOfError; 

    //name for where the MIDI file is kept
    public string fileLocation;

    //how long the note will be on the screen
    public float noteTime;

    //the Y pos where the note spawns
    public float noteSpawnY;

    //the Y pos where the note should be tapped
    public float noteTapY;

    //where the note despawns if never clicked
    public float noteDespawnY
    { 
        get
        {
            return noteTapY - (noteSpawnY - noteTapY);
        }
    }

    //offset for when the note spawns
    [Tooltip("offset for when the note spawns")]
    public double midiOffset;

    //where MIDI will load once parsed
    public static MidiFile midiFile;

    //time of the song
    float songTime;

    //pause menu script
    public UIManager buttons;

    /// //////// ///

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        songTime = audioSource.clip.length;
        Debug.Log("Audio clip length : " + songTime);

        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLocation);
        GetDataFromMidi();
    }
    void Update()
    {
        //count down song time
        songTime -= Time.deltaTime;

        if (songTime <= 0)
        {
            Debug.Log("Song over!!!!!");
            buttons.GameOver();
        }
    }

    public void GetDataFromMidi()
    {
        //get notes from file

        var notes = midiFile.GetNotes();
        //make into array
        var notesArray = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];

        //copy notes into above array. 
        notes.CopyTo(notesArray, 0);

        //filter out each time that we need for each lane (I think)
        foreach (var lane in lanes) lane.SetTimestamps(notesArray);

        //delay song so it doesn't start right away. 
        Invoke(nameof(StartSong), songDelayInSeconds);
    }

    public void StartSong()
    {
        audioSource.Play();
    }

    public static double GetAudioSourceTime()
    {
        return (double)Instance.audioSource.timeSamples / Instance.audioSource.clip.frequency;
    }

    

}
