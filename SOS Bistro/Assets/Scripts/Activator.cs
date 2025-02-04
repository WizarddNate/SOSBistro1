using UnityEngine;

public class Activator : MonoBehaviour
{
    public KeyCode key;

    bool isActive = false;

    GameObject note;

    private void Update()
    {
        //triggers when note is over the activator and is selected
        if (Input.GetKeyDown(key) && (isActive == true))
        {
            Debug.Log("Note activated");
            Destroy(note); //destroy note activator when key presses down
        }
    }

    //triggers when note collides with activator
    void OnTriggerEnter2D(Collider2D col)
    {
        isActive = true;
        Debug.Log("Activate!");

        if(col.gameObject.tag == "Note")
        {
            note = col.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isActive = false;
    }
}
