using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    public static PlayerInteract instance = null;
    public string _name = "nesto";
    public Element interact;

    void Awake()
    { 
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        transform.position = transform.position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Element>())
        {
            interact = other.GetComponent<Element>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Element>())
        {
            interact = null;
        }
    }
}
