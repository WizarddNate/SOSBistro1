using UnityEngine;

public class Pulse : MonoBehaviour
{
    public float pulseSize = 1.5f;
    public float returnSpeed = 5f;
    Vector3 startSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startSize = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, startSize, Time.deltaTime * returnSpeed);
    }

    public void Schmovement()
    {
        Debug.Log("yay! I see it!");
        transform.localScale = startSize * pulseSize;
    }
}
