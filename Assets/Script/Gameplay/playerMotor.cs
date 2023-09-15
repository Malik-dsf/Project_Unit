using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using static Unity.Burst.Intrinsics.X86;

[RequireComponent(typeof(Rigidbody))]
public class playerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    public bool inverseCamera = false;
    public bool doubleJump = true;
    public bool onTheGround = true;
    public bool secondJump = true;


    

    private Vector3 velocity;
    private Vector3 rotation;
    private float camRotationX = 0f;
    private float currentCamRotationX = 0f;
    private Rigidbody rb;

    public float cameraRotationLimit = 88f;



    private void Start(){
        Debug.Log("<b><color=red>init playerMotor</color></b>");
        rb = GetComponent<Rigidbody>();
        inverseCamera = false;

    }


    public void reversCam()
    {
        if (inverseCamera == true)
        {
            inverseCamera = false;
        }
        if (inverseCamera == false)
        {
            inverseCamera = true;
        }



    }

    public void move(Vector3 _velo){
        velocity = _velo;
    }
    public void rotate(Vector3 _rotation){
        rotation = _rotation;
    }
    public void rotateCamera(float _camRotationX)
    {
        camRotationX = _camRotationX;
    }



    public void jump(float _jumpForce)
    {
        if(onTheGround == false && doubleJump == true && secondJump == true)
        {
            onTheGround = false;
            secondJump = false;
            rb.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
            Debug.Log("DoubleJump");

        }
        if (onTheGround == true)
        {
            rb.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
            onTheGround = false;
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            StartCoroutine("wait");
            onTheGround = true;
            secondJump = true;

        }
    }

    private void FixedUpdate() {
        PerformMovement();
        PerformRotation();
    }

    private void PerformMovement(){
        if(velocity != Vector3.zero){
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    private void PerformRotation(){
        
        if(inverseCamera == true)
        {


            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
            currentCamRotationX += camRotationX;
            currentCamRotationX = Mathf.Clamp(currentCamRotationX, -cameraRotationLimit, cameraRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currentCamRotationX, 0f, 0f);

        }
        else
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
            currentCamRotationX -= camRotationX;
            currentCamRotationX = Mathf.Clamp(currentCamRotationX, -cameraRotationLimit, cameraRotationLimit);

            cam.transform.localEulerAngles = new Vector3(currentCamRotationX, 0f, 0f);

        }
    }


    private IEnumerator wait()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("<color=blue>second Jump is ready</color>");
        

    }
}
