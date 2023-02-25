using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour
{
  
    private int speed = 30;
    private void FixedUpdate()
    {
        //To rotate the speed button
        transform.Rotate(Vector3.forward * Time.deltaTime * speed);
    }
}
