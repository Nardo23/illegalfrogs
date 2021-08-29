using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int checkpointCount =0;
    [SerializeField]
    public Transform[] checkpoints;

    bool move = false;
    Transform destination;

    public float speed =1;

    // Start is called before the first frame update
    void Start()
    {
        destination = transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (move)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination.position, speed*Time.deltaTime);
            if(Vector3.Distance(transform.position, destination.position) < .25f)
            {
                transform.position = destination.position;
                move = false;
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
                destination.position = new Vector3(checkpoints[checkpointCount].position.x, transform.position.y, transform.position.z);
                checkpointCount ++;
            }
        }
        


    }




}
