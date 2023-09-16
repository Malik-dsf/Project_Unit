using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportZone : MonoBehaviour
{

    public bool actived;
    public GameObject zoneToTeleport;



    private void OnTriggerEnter(Collider other)
    {
        if (actived == true)
        {
            other.transform.position = zoneToTeleport.transform.position;
            
        }
    }
}
