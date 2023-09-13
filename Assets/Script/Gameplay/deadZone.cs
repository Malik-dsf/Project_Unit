using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadZone : MonoBehaviour
{

    public GameObject spawn;
    public int countFall;
    public Vector3 respawnPosition;

    private void Start()
    {
        respawnPosition = spawn.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag == "Player")
        {
            other.transform.position = respawnPosition;
            countFall++;
            
        }
    }


}
