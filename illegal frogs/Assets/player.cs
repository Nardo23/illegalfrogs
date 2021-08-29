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
    // Start is called before the first frame update
    void Start()
    {
        destination = checkpoints[checkpointCount];
        anim = GetComponent<Animator>();
        speakButton.SetActive(false);
        moveButton.SetActive(true);
        bubble.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (move)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, destination.position, speed * Time.deltaTime);
            //Debug.Log("curent: "+ this.transform.position+ "destination: "+ destination.position);

            if (Mathf.Abs(Vector3.Distance(this.transform.position, destination.position)) <= .25f)
            {
                //Debug.Log("position snap");
                transform.position = destination.position;
                move = false;
                anim.SetTrigger("idle");
                moveButton.SetActive(false);
                speakButton.SetActive(true);
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
    }

}
