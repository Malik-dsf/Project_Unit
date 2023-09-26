using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerAI : MonoBehaviour
{


    public Transform Target;
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject detectZone;

    public int rangeDetect;
    public int rangeAttack;
    public int range;



    // Start is called before the first frame update
    void Start()
    {
        //agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
        Target = GameObject.Find("player").transform;
        //distance = Vector3.Distance(Target.position, transform.position);
    }

    // Update is called once per frame
    void Update()
    {   
        /*if(distance > rangeDetect)
        {
            walkToTarget();
        }*/

    }

    void walkToTarget()
    {

        Collider colliderZone = detectZone.GetComponent<Collider>();

        if (colliderZone.isTrigger)
        {
            agent.destination = Target.position;

        }

    }


    void attackTarget()
    {

    }

}
