using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightPlatform : BaseTrap {

    public bool maintainRotation = true;
    public bool oneWay;
    public bool startLeft = true;
    public bool startMoving = true;
    public float moveSpeed;
    public float waitSeconds;

    public bool waiting;
    public Transform child;
    public Vector3 startpos, endpos, target;

	// Use this for initialization
	void Start () {

        if (child == null) {
            foreach (Transform a in transform) {
                child = a;
            }
        }

        if (maintainRotation) {
            child.rotation = Quaternion.identity;
        }
        
        startpos = new Vector3((GetComponent<SpriteRenderer>().size.x / -2) + 0.75f, 0, 0);
        endpos = new Vector3((GetComponent<SpriteRenderer>().size.x / 2) - 0.75f, 0, 0);

        if (startLeft) {
            target = endpos;
            child.localPosition = startpos;
        } else {

            target = startpos;
            child.localPosition = endpos;
        }

        if (oneWay && !startMoving) {
            waiting = true;
        }
            
    }


    public override void Toggle() {



        if (oneWay) {
            waiting = false;
            startMoving = true;
        } else {
            startMoving = !startMoving;
        }

    }

    public IEnumerator MovingWait() {
        waiting = true;
        yield return new WaitForSeconds(waitSeconds);
        waiting = false;
    }

        // Update is called once per frame
        void Update () {
		
        if (startMoving && !waiting && Time.timeScale != 0) {

            child.localPosition = Vector3.MoveTowards(child.localPosition, target, moveSpeed) * Time.timeScale;


            if (child.localPosition.x <= startpos.x) {
                child.localPosition = startpos;
                target = endpos;

                if (oneWay) {
                    waiting = true;
                } else {
                    if (waitSeconds > 0) StartCoroutine(MovingWait());
                }

            } else if (child.localPosition.x >= endpos.x) {
                child.localPosition = endpos;
                target = startpos;

                if (oneWay) {
                    waiting = true;
                } else {
                    if (waitSeconds > 0) StartCoroutine(MovingWait());
                }

            }
            


        }

	}
}
