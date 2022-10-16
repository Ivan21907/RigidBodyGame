using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canonControler : MonoBehaviour
{

    public GameObject bomb;
    private bool alreadyBombed;

    void Start()
    {

    }
    
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !alreadyBombed)
        {
            Debug.Log("Fire!!!");
            alreadyBombed = true;
            bomb.GetComponent<Rigidbody>().AddForce(0, 100, 1000, ForceMode.Acceleration);

        }
    }
}
