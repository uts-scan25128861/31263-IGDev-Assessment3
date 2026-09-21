using UnityEngine;

public class Movement : MonoBehaviour
{

    // private float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ResetState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetState()
    {
        this.enabled = true;
    }
}
