using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsPickup : MonoBehaviour
{

    [SerializeField]
    private LayerMask PickupMask;
    [SerializeField]
    private Camera PlayerCamera;
    [SerializeField]
    private Transform PickupTarget;
    [Space]
    [SerializeField]
    private float PickupRange;
    private Rigidbody CurrentObject;

    public GameObject text_print;
    public GameObject pointer_nograb;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("<b><color=green>init PhisicsPickup </color></b>");
    }

    // Update is called once per frame
    void Update()
    {
        Ray CameraRay1 = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if(Physics.Raycast(CameraRay1, out RaycastHit hitInfo1, PickupRange, PickupMask))
        {
            text_print.SetActive(true);
        }
        else
        {
            text_print.SetActive(false);

        }

        if (Input.GetKeyUp(KeyCode.Mouse0)){

            if (CurrentObject)
            {
                CurrentObject.useGravity = true;
                CurrentObject = null;
                return;
            }


            Ray CameraRay = PlayerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(CameraRay, out RaycastHit hitInfo, PickupRange, PickupMask))
            {
                CurrentObject = hitInfo.rigidbody;
                CurrentObject.useGravity = false;
            }
            else
            {
            }
        }

        

    }

    private void FixedUpdate()
    {
        if(CurrentObject)
        {
            text_print.SetActive(false);
            Vector3 DirectionToPoint = PickupTarget.position - CurrentObject.position;
            float DistanceToPoint = DirectionToPoint.magnitude;

            CurrentObject.velocity = DirectionToPoint * 12f * DistanceToPoint;
            Debug.Log("grab");

        }
    }
}
