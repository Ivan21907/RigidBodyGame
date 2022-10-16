using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{

    public float enemyForce = 5f;
    public float enemyInjure = 1f;
  

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {

        if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy collision");
            //other.gameObject.Destroy;

        }

        if(other.gameObject.tag == "Dead")
        {
            Debug.Log("Enemy down. YOU WIN");
            Destroy (this.gameObject);
        }

    }
}
