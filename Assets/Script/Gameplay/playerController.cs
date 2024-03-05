using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

[RequireComponent(typeof(playerMotor))]
public class playerController : MonoBehaviour
{
    
    public float speed;
    public float walkSpeed = 7.5f;
    public float runSpeed = 10f;

    public Camera cam;


    public float sencibilityX = 5f;
    [SerializeField]
    private float saveX = 0f;
    public float sencibilityY = 5f;
    private float saveY = 0f;
    [SerializeField]
    private string InputFlashlight = "F";
    public GameObject flashlight;

    public float forceJump = 10;

    private playerMotor motor;
    public bool running = false;
    public bool jumping = true;
    public bool lockMouse = false;
    public bool lockMouseX = false;
    public bool lockMouseY = false;
    public bool moveActive = true;
    public bool camActive = true;


    void Start()
    {
        Debug.Log("<b><color=green>init playerController</color></b>");

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

        if (moveActive == true)
        {
            float xMov = Input.GetAxis("Horizontal");
            float zMov = Input.GetAxis("Vertical");


            if (Input.GetKey(KeyCode.F))
            {
                flashlight.SetActive(true);
            }
            else
            {
                flashlight.SetActive(false);
            }


            Vector3 moveHorizontal = transform.right * xMov;
            Vector3 moveVertical = transform.forward * zMov;

            //course
            if (running == true)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Running();
                    cam.fieldOfView = 80.0f;
                }
                else
                {
                    speed = walkSpeed;
                    cam.fieldOfView = 75.0f;
                }

            }

            if (jumping == true)
            {
                if (Input.GetKeyDown(KeyCode.Space) == true)
                {
                    motor.jump(forceJump);
                }
            }
            Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

            motor.move(velocity);
        }
        
        #endregion


        #region sourie

        if(camActive == true)
        {
            if (lockMouse == true)
            {
                lockMouseX = true;
                lockMouseY = true;
            }


            if (lockMouseX == true)
            {
                saveX = sencibilityX;
                Debug.Log(saveX);
                sencibilityX = 0f;
            }
            if(lockMouseX == false)
            {
                sencibilityX = saveX;
            }

            if(lockMouseY == true)
            {
                saveY = sencibilityY;
                sencibilityY = 0f;
            }

            if(lockMouseY == false)
            {
                sencibilityY = saveY;
            }

            float yRot = Input.GetAxisRaw("Mouse X");

            Vector3 rota = new Vector3(0, yRot, 0) * sencibilityX;
            motor.rotate(rota);



            float xRot = Input.GetAxisRaw("Mouse Y");

            float camRotaX = xRot * sencibilityY;

            motor.rotateCamera(camRotaX);
        }
        
        #endregion


    }


    private void Running()
    {
        speed += 1;
        if(speed >= runSpeed)
        {
            speed = runSpeed;
        }
    }
}
