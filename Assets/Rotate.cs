using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float RotateAmount = 0.1f;

    public bool right;
    public bool up;

    bool dragging = false;
    Rigidbody rb;


    private Quaternion rotationY;

    //public bool rotate;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }


    }
    void OnMouseDrag()
    {
        dragging = true;
        /*Debug.Log("mouse drag");*/
    }

    void FixedUpdate()
    {
        if (dragging)
        {
/*            float x = Input.GetAxis("Mouse X") * RotateAmount;
            float y = Input.GetAxis("Mouse Y") * RotateAmount;*/

            float x = Input.GetTouch(0).deltaPosition.x * RotateAmount;
            float y = Input.GetTouch(0).deltaPosition.y * RotateAmount;

            rotationY = Quaternion.Euler(y, -x, 0);

            rb.transform.rotation = rotationY * transform.rotation;


        }
    }
}
