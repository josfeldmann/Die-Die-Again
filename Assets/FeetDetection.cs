using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetDetection : MonoBehaviour {

    public bool canJump;
   


    int num = 0;

    public void OnTriggerEnter2D(Collider2D col) {

        if (col.transform.parent && col.transform.parent.tag == "MovingPlatform") {
            transform.parent.parent = col.transform;
        }

        num++;
        canJump = true;

    }

    public void OnTriggerExit2D(Collider2D col) {

        if (col.transform.parent && col.transform.parent.tag == "MovingPlatform") {
            transform.parent.parent = null ;
        }

        num--;
        if (num <= 0) {
            canJump = false;
            num = 0;
            
        }

    }

}
