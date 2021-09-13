using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public GameObject Player;
    public float parallaxWait;
    float prevX;
    float newX;
    float timer;
    public float strength;
    // Start is called before the first frame update
    void Start()
    {
        prevX = Player.transform.position.x;
        newX = 0f;
    }

    // Update is called once per frame
    
    
    private void FixedUpdate()
    {
        if (Player.transform.position.x != prevX && timer >= parallaxWait)
        {
            newX = .125f*strength;
            transform.position = new Vector3(transform.position.x +newX, transform.position.y , transform.position.z);
            timer = 0;

        }
        else if (Player.transform.position.x != prevX)
        {
            timer+= Time.deltaTime;
        }


        prevX = Player.transform.position.x;
    }

}

