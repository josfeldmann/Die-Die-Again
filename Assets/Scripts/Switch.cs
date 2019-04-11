using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour {

    public BaseTrap[] traps;
    public string interactMessage = "Press E to Flip Switch";
    public Text interactText;

    public bool isActiveOnStart;
    bool state;

    public void FlipSwitch() {

        state = !state;

        for (int i = 0; i < traps.Length; i++) {
            traps[i].Toggle();
        }

        if (GetComponent<Animator>() != null) {

            string s = "RightLeft";
            if (state) s = "LeftRight";

            GetComponent<Animator>().SetTrigger(s);
        }

    }


	// Use this for initialization
	void Start () {


        interactText.transform.parent.gameObject.SetActive(false);
        state = false;

        if (isActiveOnStart) {
            FlipSwitch();
        }
	}

    bool playerTouching = false;

    public void OnTriggerEnter2D(Collider2D col) {

        if (col.transform.tag == "Player") {
            interactText.transform.parent.gameObject.SetActive(true);
            interactText.text = interactMessage;
            playerTouching = true;
        }

    }


    public void Update() {
        if (playerTouching && Input.GetButtonDown("Interact")) {
            FlipSwitch();
        }
    }


    public void OnTriggerExit2D(Collider2D col) {

        if (col.transform.tag == "Player") {

            interactText.transform.parent.gameObject.SetActive(false);
            interactText.text = "";
            playerTouching = false;
        }

    }



}
