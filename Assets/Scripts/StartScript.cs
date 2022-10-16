using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Starting...");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(Time.deltaTime + "seg. - " + 1.0f/Time.deltaTime + "FPS");
    }
}
