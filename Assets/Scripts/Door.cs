using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BaseTrap {

    public bool isActiveOnStart;

    public bool state;

    public void Start() {

        state = false;

        if (isActiveOnStart) {
            Toggle();
        } else {
            
        }
    }

	public override void Toggle() {

        state = !state;

        if (state) {
            GetComponent<Animator>().SetTrigger("Up");
        } else {
            GetComponent<Animator>().SetTrigger("Down");
        }

    }
}
