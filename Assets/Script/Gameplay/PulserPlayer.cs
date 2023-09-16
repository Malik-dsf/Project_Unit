using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulserPlayer : MonoBehaviour
{

    public bool IsDestroable;
    public GameObject plateform;
    public playerController playercontroller;
    public float forceJump = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            Debug.Log("<b><color=blue>Jumpper detected </color></b>");
            playercontroller.GetComponent<Rigidbody>().AddForce(new Vector3(0, forceJump, 0), ForceMode.Impulse);

            if (IsDestroable == true)
            {
                Destroy(plateform);
            }
        }
    }
}
