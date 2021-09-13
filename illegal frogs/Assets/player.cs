using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int checkpointCount = 0;
    [SerializeField]
    public Transform[] checkpoints;

    bool move = false;
    Transform destination;
    Animator anim;
    public float speed = 1;
    public GameObject moveButton;
    public GameObject speakButton;
    public GameObject bubble;
    public GameObject cop;
    public GameObject eatButton;
    bool reset = false;
    bool eaten = false;
    AudioSource sor;
    [SerializeField]
    AudioClip[] hop1;
    [SerializeField]
    AudioClip[] hop2;
    bool firsthop = false;
    public Vector2 pitchRange;
    public GameObject endScreen;
    public Transform playerParent;
    public AudioClip bite;
    public AudioClip talk;
    public GameObject crimes;
    public float crimeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        sor = GetComponent<AudioSource>();
        destination = checkpoints[checkpointCount];
        anim = GetComponent<Animator>();
        speakButton.SetActive(false);
        moveButton.SetActive(true);
        bubble.SetActive(false);
        cop.SetActive(false);
        eatButton.SetActive(false);
        endScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (move)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, destination.position, speed * Time.deltaTime);
            crimes.transform.position = new Vector3(crimes.transform.position.x - crimeSpeed * Time.deltaTime, crimes.transform.position.y, crimes.transform.position.z);
            //Debug.Log("curent: "+ this.transform.position+ "destination: "+ destination.position);
            if (Mathf.Abs(Vector3.Distance(this.transform.position, destination.position)) <=7 && !reset)
            {
                cop.SetActive(false);
                reset = true;
            }
            if (Mathf.Abs(Vector3.Distance(this.transform.position, destination.position)) <= 6)
            {
                cop.transform.position = new Vector3(transform.position.x+2, cop.transform.position.y, cop.transform.position.z);
                cop.transform.parent = this.transform;
                cop.SetActive(true);
            }
            if (Mathf.Abs(Vector3.Distance(this.transform.position, destination.position)) <= .25f)
            {
                //Debug.Log("position snap");
                transform.position = destination.position;
                move = false;
                anim.SetTrigger("idle");
                moveButton.SetActive(false);
                if (checkpointCount == checkpoints.Length)
                {
                    eatButton.SetActive(true);
                }
                else
                {
                    
                    speakButton.SetActive(true);
                    cop.transform.parent = null;
                    reset = false;
                }
            }



        }


    }

    public void nextCheckpoint()
    {
        if (!move)
        {
            if (checkpointCount < checkpoints.Length)
            {
                
                move = true;
                destination = checkpoints[checkpointCount];
                destination.position = new Vector3(checkpoints[checkpointCount].position.x, transform.position.y, transform.position.z);
                checkpointCount++;
                anim.SetTrigger("hop");
                //Debug.Log(checkpointCount);
            }
        }



    }

    public void toggle()
    {
        moveButton.SetActive(true);
        speakButton.SetActive(false);
    }
    public void speak()
    {
        bubble.SetActive(true);
        speakButton.SetActive(false);
        talkSound();
    }
    public void eat()
    {
        if (!eaten)
        {
            eaten = true;
            anim.SetTrigger("eat");
            cop.SetActive(false);
            speakButton.SetActive(false);
            eatButton.SetActive(false);
        }
        
    }

    void hopSound()
    {
        if (firsthop)
        {
            sor.volume = 1f;
            sor.pitch = Random.Range(pitchRange.x, pitchRange.y);
            sor.PlayOneShot(hop2[Random.Range(0,hop2.Length)]);
            firsthop = !firsthop;
        }
        else
        {
            sor.volume = 1f;
            sor.pitch = Random.Range(pitchRange.x, pitchRange.y);
            sor.PlayOneShot(hop1[Random.Range(0, hop1.Length)]);
            firsthop = !firsthop;
        }
        //Debug.Log(firsthop);
    }

    public void end()
    {
        endScreen.transform.position = transform.position;
        endScreen.SetActive(true);
        //transform.SetParent(playerParent);
        speakButton.SetActive(false);
        eatButton.SetActive(false);
    }

    void biteSound()
    {
        sor.pitch = 1;
        sor.volume = 1f;
        sor.PlayOneShot(bite);

    }
    void talkSound()
    {
        sor.volume = .65f;
        sor.pitch = 1;
        sor.PlayOneShot(talk);
    }

}
