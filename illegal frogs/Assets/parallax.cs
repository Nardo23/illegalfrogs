using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public GameObject Player;
    public float parallaxStrength;
    float prevX;
    float newX;
    // Start is called before the first frame update
    void Start()
    {
        prevX = Player.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x != prevX)
        {
            newX += Mathf.Abs(Player.transform.position.x - prevX) * parallaxStrength;
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }


        prevX = Player.transform.position.x;
    }
}
