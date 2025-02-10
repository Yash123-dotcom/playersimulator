using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movespeed = 5f;
    public float rotationspeed = 200f;

    private Rigidbody rb;
    private Vector3 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float movex = Input.GetAxis("Horizontal");
        float movez = Input.GetAxis("Vertical");

        moveDirection = new Vector3(movex, 0, movez).normalized;
        if(moveDirection!=Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationspeed * Time.deltaTime);
        }

        
    }

     void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveDirection * movespeed * Time.fixedDeltaTime); 
        
    }
}
