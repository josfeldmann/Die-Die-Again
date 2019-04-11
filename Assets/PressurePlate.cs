using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour {

    public Animator anim;
    bool active = false, inAnim = false;
    public int num = 0;


    public BaseTrap[] traps;


	// Use this for initialization
	void Start () {
        //anim = GetComponent<Animator>();
	}

    public void ToggleTraps() {
        active = !active;
        foreach(BaseTrap b in traps) {
            b.Toggle();
        }

    }

	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter2D(Collider2D col) {
        num++;
        if (!active) {
            ToggleTraps();
            anim.SetTrigger("Down");
        }
    }

    public void OnTriggerExit2D(Collider2D col) {
        num--;

        if (num <= 0) {
            ToggleTraps();
            anim.SetTrigger("Up");
        }
        
    }
}
