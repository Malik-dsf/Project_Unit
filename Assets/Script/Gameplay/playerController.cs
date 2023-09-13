using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

[RequireComponent(typeof(playerMotor))]
public class playerController : MonoBehaviour
{
    
    public float speed = 10f;


    public float sencibilityX = 5f;
    [SerializeField]
    private float saveX = 0f;
    public float sencibilityY = 5f;
    private float saveY = 0f;

    public float forceJump = 10;

    private playerMotor motor;
    public bool running = false;
    public bool jumping = true;
    public bool lockMouse = false;
    public bool lockMouseX = false;
    public bool lockMouseY = false;


    void Start()
    {
        Debug.Log("<b>init playerController</b>");

        motor = GetComponent<playerMotor>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        saveX = sencibilityX;
        Debug.Log(saveX);
        saveY = sencibilityY;
        Debug.Log(saveY);


    }


    void Update()
    {
        
        #region clavier
        float xMov = Input.GetAxis("Horizontal");
        float zMov = Input.GetAxis("Vertical");
        

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        //course
        if(running == true){
        Debug.Log("Run");

        }

        if (jumping == true)
        {
            if(Input.GetKeyDown(KeyCode.Space) == true) {
                motor.jump(forceJump);
            }
        }
        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.move(velocity);
        #endregion


        #region sourie

        if(lockMouse == true)
        {
            lockMouseX = true;
            lockMouseY = true;
        }
        

        if(lockMouseX == true)
        {
            saveX = sencibilityX;
            Debug.Log(saveX);
            sencibilityX = 0f;
        }
        if(lockMouseX == false){
            sencibilityX = saveX;
        }

        if (lockMouseY == true)
        {
            saveY = sencibilityY;
            sencibilityY = 0f;
        }
        if(lockMouseY == false)
        {
            sencibilityY = saveY;
        }






        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rota = new Vector3(0,yRot,0) * sencibilityX;
        motor.rotate(rota);



        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 camRota = new Vector3(xRot, 0, 0) * sencibilityY;
      
        motor.rotateCamera(camRota);
        #endregion


    }
}
