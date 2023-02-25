using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScripts : PLayerInfoManager
{

    [SerializeField]
    private GameObject ARCamera;
    //Particles for destroyed bird
    [SerializeField]
    private GameObject[] particles;
    [SerializeField]
    GameObject scoreBar;

    PLayerInfoManager scoreManager;
    public void Awake()
    {
        scoreManager = scoreBar.GetComponent<PLayerInfoManager>();
    }
    //When palyer press the shoot button from ArCamera it transfer a Raycasthit 
    //If its hit the birds, it will destroy bird gameobject and play the specific particle depends on its color
    public void shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(ARCamera.transform.position, ARCamera.transform.forward, out hit)) {
            if (hit.transform.name == "RedBird(Clone)" || hit.transform.name == "BlueBird(Clone)" || hit.transform.name == "GrayBird(Clone)")
            {
                if (hit.transform.name == "RedBird(Clone)")
                    Instantiate(particles[2], hit.point, Quaternion.LookRotation(hit.normal));
                else if (hit.transform.name == "BlueBird(Clone)")
                    Instantiate(particles[0], hit.point, Quaternion.LookRotation(hit.normal));
                else if (hit.transform.name == "GrayBird(Clone)")                
                    Instantiate(particles[1], hit.point, Quaternion.LookRotation(hit.normal));

                Destroy(hit.transform.gameObject);
                //To update the score
                scoreManager.PlayerScore += 1;
                scoreManager.PlayerLevelScore += 1;
                scoreManager.UpdateScore();
            }

        }

    }
}
