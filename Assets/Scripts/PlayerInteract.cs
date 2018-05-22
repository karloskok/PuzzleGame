using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    public static PlayerInteract instance = null;
    public string _name = "nesto";
    public Element interact;

    public GameObject canvas;

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
        if(canvas)
            canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                canvas.SetActive(!canvas.activeSelf);
            }

            if (canvas.activeSelf)
            {
                Time.timeScale = 0;
            }
            else
                Time.timeScale = 1;
        }

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
