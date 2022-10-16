using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceControler : MonoBehaviour
{
    public float bounceForce = 5;
    /*public Audio audioBounce;
    public Audio audioSource;*/
    /*private AudioSource audioSource;
    public AudioClip audioBounce;*/

    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Bouncing");
            /*AudioSource.clip = audioBounce;
            AudioSource.Play();*/
            
            other.rigidbody.AddForce(0, bounceForce, bounceForce, ForceMode.Impulse);

        }

        
    }
    

}
