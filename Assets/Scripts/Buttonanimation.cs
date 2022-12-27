using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonanimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void buttonClick()
    {
        GetComponent<Animation>().Play("Button");
    }
    
}
