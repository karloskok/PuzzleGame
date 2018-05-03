using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Transform cam;
    Transform camHolder;
    Rigidbody rigid;
    BoxCollider capColl;

    Vector3 storeDirection;
    Vector3 directionPosition;
    Vector3 velocity;

    float vertical, horizontal;
    public float moveSpeed = 1;
    public float turnSpeed = 1;


	// Use this for initialization
	void Start () {

        cam = Camera.main.transform;
        camHolder = cam.parent.parent;
        rigid = GetComponent<Rigidbody>();
        capColl = GetComponent<BoxCollider>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        storeDirection = camHolder.right;
	}

    void FixedUpdate()
    {

        MovementNormal();

    }

    private void MovementNormal()
    {
        directionPosition = transform.position + (storeDirection * horizontal) + (camHolder.forward * vertical);  ///(cam.forward * vertical);
        Vector3 dir = (directionPosition - transform.position).normalized;
        dir.y = 0;
        Debug.DrawRay(transform.position, dir, Color.red, .2f);

        float angle = Vector3.Angle(transform.position, dir);
        if(horizontal != 0 || vertical != 0)
        {
            if (angle != 0)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), turnSpeed * Time.deltaTime);
            }
        }

        //transform.position = Vector3.SmoothDamp(transform.position, transform.position + dir, ref velocity, .5f);
        //transform.Translate((dir * moveSpeed * Time.deltaTime));
        transform.position += dir * moveSpeed * Time.deltaTime;
    }
}
