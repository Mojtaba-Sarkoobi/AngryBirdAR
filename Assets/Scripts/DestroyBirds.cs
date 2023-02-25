using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBirds : MonoBehaviour
{

    [SerializeField]
    private GameObject PlayerInfo;

    private PLayerInfoManager playerInfoManager;
    private void Start()
    {
        playerInfoManager = PlayerInfo.GetComponent<PLayerInfoManager>();
    }

    //If other gameobject collide with sphere collider
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
        //To change the player health
        playerInfoManager.PlayerHealth -= 1;
        playerInfoManager.UpdateHealth();
    }
}
