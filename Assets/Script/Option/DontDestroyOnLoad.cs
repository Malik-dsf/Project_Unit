using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{

    public bool dontDestroy;


    // Start is called before the first frame update
    void Start()
    {

        if (dontDestroy)
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
