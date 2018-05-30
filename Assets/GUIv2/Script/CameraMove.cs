using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    public Transform currentMount;
    public float speedFactor = 0.1f;
	
	// Update is called once per frame
	void Update () {
        transform.position = Vector3.Lerp(transform.position, currentMount.position, speedFactor * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, speedFactor * Time.deltaTime);
	}

    public void setPosition(Transform newMount)
    {
        currentMount = newMount;
    }
}
