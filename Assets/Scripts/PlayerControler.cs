using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControler : MonoBehaviour
{
    //Variables publiques

    public float speed = 5f;
    public float jumpForce = 5f;
    public float playerLife = 10f;
    public float bounceForce = 5f;
    public Slider slider;
    public AudioClip audioHit;
    public AudioClip audioJump;
    public AudioClip audioBounce;
    public AudioClip audioDeath;
    public AudioClip audioGoal;
    public ParticleSystem particles;

    //Variables privades

    private Rigidbody rb;
    private Vector3 initialPosition;
    private bool isGrounded = false;
    private float enemyInjure;
    private float enemyForce;
    private AudioSource audioSource;
    //private ParticleSystem particles;
    private bool sceneEnded = false;
    private bool isDead = false;

    //Constants
    private float DEATH_POS = -5f;

    // Start is called before the first frame update
    void Start()
    {
        //donar-li un rigidbody
        rb = GetComponent<Rigidbody>();
        //per agafar el so que volem en cada moment
        audioSource = GetComponent<AudioSource>();
        //dir-li que quan es caigui el player torni a la posicio inicial
        initialPosition = transform.position;
        //li diem que el slider va disminuint la vida
        slider.value = playerLife;

    }

    // Update is called once per frame
    void Update()
    {
        if(!sceneEnded && !isDead)
        {
            //Moviment 
            float xDirection = Input.GetAxis("Horizontal");
            float zDirection = Input.GetAxis("Vertical");
            Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);



            if(moveDirection.magnitude >= 0.1f)//if minimum movement move position
            {
                //Debug.Log("x-" + xDirection + " z-" + zDirection);
                transform.Translate(moveDirection * speed * Time.deltaTime);
            }

            //Salt
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                rb.AddForce(0.0f, jumpForce, 0f, ForceMode.Impulse);
                audioSource.clip = audioJump;
                audioSource.Play();
                particles.Play();
            }

            //Mort 
            if(!isDead && (transform.position.y <= DEATH_POS || playerLife <= 0))
            {
                isDead = true;
                Debug.Log("YOU LOOSE");
                //transform.position = initialPosition;
                //escena mort
                StartCoroutine(PlayFullAudioLooby(audioDeath));
            }
        }


    }

    private void OnCollisionStay(Collision other)
    {
        /*if(other.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy collision");
            //other.gameObject.Destroy;

        }*/

        if(other.gameObject.tag == "Ground")
        {
            //Debug.Log("on floor");
            isGrounded = true;

        }
    }

    private void OnCollisionEnter(Collision other)
    {    
        if(other.gameObject.tag == "Enemy")
        {
            enemyInjure = other.gameObject.GetComponent<EnemyControler>().enemyInjure;
            playerLife -= enemyInjure;
            slider.value = playerLife;
            audioSource.clip = audioHit;
            audioSource.Play();
            Debug.Log("Injured! LIVE=" + playerLife + " (" + enemyInjure + ")");
            //quan t'impulsi l'enemic
            enemyForce = other.gameObject.GetComponent<EnemyControler>().enemyForce;
            rb.AddForce(0f, enemyForce, -enemyForce, ForceMode.Impulse);

            //transform.position = initialPosition;
        }

        /*if(other.gameObject.tag == "Bounce")
        {
             //audioSource.
            Debug.Log("Bouncing");
            audioSource.clip = audioBounce;
            audioSource.Play();
            other.rigidbody.AddForce(0, bounceForce, bounceForce, ForceMode.Impulse);

            //transform.position = initialPosition;
        }*/

        
    }

  
    private void OnCollisionExit(Collision other)
    {

        if(other.gameObject.tag == "Ground")
        {
            //Debug.Log("exit ground");
            isGrounded = false;

        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
         if(other.gameObject.tag == "Goal")
        {
            Debug.Log("WELL DONE");
            rb.isKinematic = true;
            sceneEnded = true;
            //crida asincrona per fer que soni el soroll i despres s'obre la seguent escena
            StartCoroutine(PlayFullAudioNextScene(audioGoal)); 

        }
    }

    IEnumerator PlayFullAudioNextScene(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play(); 
        Debug.Log("Playing");
        //yield return new WaitForSeconds(5f);
        //yield return new WaitForSeconds(audioSource.clip.length);
        yield return new WaitForSeconds(audio.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator PlayFullAudioLooby(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play(); 
        Debug.Log("Death");
        //yield return new WaitForSeconds(5f);
        //yield return new WaitForSeconds(audioSource.clip.length);
        yield return new WaitForSeconds(audio.length);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Looby");
    }
}
