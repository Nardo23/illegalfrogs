using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{
    public player playerScript;
    // Start is called before the first frame update
    public void toggleButtons()
    {
        playerScript.toggle();
        this.gameObject.SetActive(false);
    }


}
