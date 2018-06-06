using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour {
    bool haveKey = false;
    bool haveWire = false;
    public GameObject wireObject, numbers, door, keypad, portal, lever;
    public Camera camTV, camKeyPad, maincam;
    Movement plMovement;
    public LayerMask layerMask;
    public List<GameObject> buttons;
    int[] correct, current;
    public UnityEngine.UI.Text text;
    public Canvas HelpText;

	// Use this for initialization
	void Start () {
        HelpText.enabled = false;
        wireObject.GetComponent<BoxCollider>().enabled = false;
        camKeyPad.enabled = false;
        camTV.enabled = false;
        maincam = Camera.main;

        plMovement = GetComponent<Movement>();

        foreach (GameObject b in buttons){
            b.GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        correct = new int[] { 0, 0, 1, 1, 0, 0, 0, 1, 0, 1, 0, 0};
        current = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }

    // Update is called once per frame
    void Update () {
        if (!numbers.GetComponent<Animation>().isPlaying && !camKeyPad.enabled){
            camTV.enabled = false;
            maincam.enabled = true;
            plMovement.enabled = true;
        }

        if (camKeyPad.enabled == true && Input.GetKeyDown(KeyCode.Escape) ) {
            camKeyPad.enabled = false;
            maincam.enabled = true;
            plMovement.enabled = false;
        }

        RaycastHit hit;
        if (Input.GetMouseButtonDown(0)){
            Ray ray = camKeyPad.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, layerMask)){
                for(int i = 0; i < 12; i++){
                    if (hit.transform.name == buttons[i].name){
                        if (hit.transform.gameObject.GetComponent<MeshRenderer>().material.color == Color.yellow){
                            hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
                            current[i] = 1;
                        }
                        else{
                            hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
                            current[i] = 0;
                        }
                    }
                }
            }
        }

        bool indicator = true;

        for(int i =0; i< 12; i++){
            if(current[i] != correct[i]){
                indicator = false;
            }
        }

        if (indicator  && camKeyPad.enabled){
            door.GetComponent<Animation>().Play();
            camKeyPad.enabled = false;
            maincam.enabled = true;
            plMovement.enabled = true;
            keypad.GetComponent<BoxCollider>().enabled = false;
            text.text = "";
        }
    }

    private void OnTriggerStay(Collider other){

        if (other.gameObject.name == "KeyPad" && Input.GetKeyDown(KeyCode.E)) {
            camKeyPad.enabled = true;
            maincam.enabled = false;
            plMovement.enabled = false;
            return;
        }

        HelpText.enabled = true;

        if (other.gameObject.name == "key") {
            text.text = "Press E to pick up key";
        }
        else if (other.gameObject.name == "wire") {
            text.text = "Press E to pick up wire";
        }
        else if (other.gameObject.name == "Opener") {
            text.text = "Press E to open the box";
        }
        else if (other.gameObject.name == "tv") {
            text.text = "Press E to start tv";
        }
        else if (other.gameObject.name == "KeyPad") {
            text.text = "Press E to enter password";
            if (camKeyPad.enabled) {
                text.text = "Press ESC to finish";
            }
        }

        if(other.gameObject.name == "key" && Input.GetKeyDown(KeyCode.E)){
            other.gameObject.SetActive(false);
            haveKey = true;
            text.text = "";
        }

        if (other.gameObject.name == "Opener" && Input.GetKeyDown(KeyCode.E) && haveKey){
            
            if (!haveWire && !haveKey) {
                return;
            }

            other.gameObject.GetComponent<Animation>().Play();
            haveKey = false;

            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
            StartCoroutine(whait());
        }

        if (other.gameObject.name == "wire" && Input.GetKeyDown(KeyCode.E)){
            haveWire = true;
            other.gameObject.SetActive(false);
            text.text = "";
        }

        if (other.gameObject.name == "tv" && Input.GetKeyDown(KeyCode.E) && haveWire){
            haveWire = false;
            camTV.enabled = true;
            maincam.enabled = false;
            numbers.GetComponent<Animation>().Play();
            plMovement.enabled = false;
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
        if (other.gameObject.name == "LeverTrigger" && Input.GetKeyDown(KeyCode.E)) {
            
            portal.GetComponent<Animation>().Play();
            lever.GetComponent<Animation>().Play();
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        if (other.gameObject.name == "Portal") {

            UnityEngine.SceneManagement.SceneManager.LoadScene("Level1");
        }
        if (other.gameObject.name.Contains("Restart")) {

            UnityEngine.SceneManagement.SceneManager.LoadScene("Intro");
        }
    }

    private void OnTriggerExit(Collider other) {
        HelpText.enabled = false;
    }

    IEnumerator whait(){
        yield return new WaitForSeconds(3);
        wireObject.GetComponent<BoxCollider>().enabled = true;
    }
}
