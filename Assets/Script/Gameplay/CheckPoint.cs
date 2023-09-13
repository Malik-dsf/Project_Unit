using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{

    deadZone deathzone;
    public bool IsDestroable = false;


    private void Start()
    {
        deathzone = GameObject.Find("Deathzone").GetComponent<deadZone>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.gameObject.tag == "Player")
        {
            deathzone.respawnPosition = gameObject.transform.position;
            Debug.Log("checkpoint");

            if (IsDestroable == true)
            {
                Destroy(gameObject);
            }
        }
    }

    }
