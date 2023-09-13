using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

[RequireComponent(typeof(Rigidbody))]
public class playerMotor : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    public bool inverseCamera = false;


    private Vector3 velocity;
    private Vector3 rotation;
    private Vector3 camRotation;
    private Rigidbody rb;


    private void Start(){
        rb = GetComponent<Rigidbody>();
    }

    public void move(Vector3 _velo){
        velocity = _velo;
    }
    public void rotate(Vector3 _rotation){
        rotation = _rotation;
    }
    public void rotateCamera(Vector3 _camRotation)
    {
        camRotation = _camRotation;
    }

    public void jump(float _jumpForce)
    {
        rb.AddForce(new Vector3(0,_jumpForce,0), ForceMode.Impulse);
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
            rb.MoveRotation(rb.rotation * Quaternion.Euler(-rotation));
            cam.transform.Rotate(camRotation);

        }
        else
        {
            rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
            cam.transform.Rotate(-camRotation);
        }
    }


}
