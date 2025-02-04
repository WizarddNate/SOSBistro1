using UnityEngine;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using System.IO;
using UnityEngine.Networking;

public class SongManager : MonoBehaviour
{

    public static SongManager Instance;
    public AudioSource audioSource;

    //delay our song after a certain time
    public float songDelayInSeconds;
    public int inputDelayInMilliseconds;

    //name for where the MIDI file is kept
    public string fileLoctation;

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

    //where MIDI will load once parsed
    public static MidiFile midiFile;
    
    void Start()
    {
        Instance = this;

        //read Midi file.. this might not work because i put the file in a different spot from the tutorial
        midiFile = MidiFile.Read(Application.streamingAssetsPath + "/" + fileLoctation);
    }

    
    void Update()
    {
        
    }

    public void GetDataFromMidi()
    {
        //get notes from file
        var notes = midiFile.GetNotes();

        //make into array
        var notesArray = new Melanchall.DryWetMidi.Interaction.Note[notes.Count];

        //copy notes into above array. Not sure why it doesn't work!
        notes.CopyTo(notesArray, 0);


        //delay song so it doesn't start right away. Will come back to this later
        Invoke(nameof(StartSong), songDelayInSeconds);
        {
            audioSource.Play();
        }
    }

    public void StartSong()
    {

    }
}
