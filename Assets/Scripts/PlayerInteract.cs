using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

    public static PlayerInteract instance = null;
    public string _name = "nesto";
    public Element interact;

    public GameObject canvas;
    // Sluzi za provjeru da li je Settings otvoren ili nije
    public GameObject canvasMainMenu;

    // Animator 
    private Animator animGUIdialog;

    public GameObject PressECanvas;

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

        animGUIdialog = PressECanvas.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canvas)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (canvasMainMenu.activeSelf)
                {
                    canvas.SetActive(!canvas.activeSelf);
                }
            }
            if (canvas.activeSelf) Time.timeScale = 0;
            else Time.timeScale = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Element>())
        {
            interact = other.GetComponent<Element>();
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Area"))
        {
            PressECanvas.transform.position = other.transform.position + new Vector3(0, 2f, 0);
            PressECanvas.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Element>())
        {
            interact = null;
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("Area"))
        {
            StartCoroutine(CloseGUIPressDialog());            
        }
    }

    private IEnumerator CloseGUIPressDialog(int i = 0)
    {
        animGUIdialog.SetTrigger("Leave");
        yield return new WaitForSeconds(0.9f);
        PressECanvas.SetActive(false);
    }
}