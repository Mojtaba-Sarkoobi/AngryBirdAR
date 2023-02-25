using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsFly : MonoBehaviour
{
    //speed of every bird
    private float speed = 0.3f;

    void Update()
    {
        //To move the birds
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    //Properties for speed
    public float BirdSpeed {
        get 
        {
            return speed;    
        }

        set
        {
            speed = value;
        }
    }
}
