using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copSound : MonoBehaviour
{
    AudioSource sor;
    public AudioSource talkSor;
    [SerializeField]
    AudioClip[] footsteps;
    [SerializeField]
    AudioClip[] trombone;
    public Vector2 pitchRange;
    public Vector2 talkPitchRange;

    public Vector2 Amount;
    bool started = false;
    public Vector2 timeRange;
    float timeGoal;
    // Start is called before the first frame update
    void Start()
    {
        sor = GetComponent<AudioSource>();
        timeGoal = Random.Range(timeRange.x, timeRange.y);
    }

    void stepSound()
    {
        sor.pitch = Random.Range(pitchRange.x, pitchRange.y);
        sor.PlayOneShot(footsteps[Random.Range(0, footsteps.Length)]);

    }
    float q = 0;
    float i = 0;
    float timer = 0;
    
    void Update()
    {
        if (started)
        {
            timer += Time.deltaTime;


            //Debug.Log(timer);
            if (q < i)
            {
                if (timer < timeGoal)
                {

                }
                else
                {
                    talkSor.pitch = Random.Range(talkPitchRange.x, talkPitchRange.y);
                    talkSor.PlayOneShot(trombone[Random.Range(0, trombone.Length)]);
                    timeGoal = Random.Range(timeRange.x, timeRange.y);
                    timer = 0;
                    q++;
                }
            }
            else
            {
                //Debug.Log("piss");
                started = false;
            }
        }


        
    }


    void speech()
    {
        
        started = true;
        i = Random.Range(Amount.x, Amount.y);
        timer = 100;
        q = 0;
    }



}
