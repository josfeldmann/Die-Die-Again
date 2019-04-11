using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController> {


    Transform target;
    public float zvalue = -10;
    public float cameraMoveSpeed = 0.01f;
    Vector3 thing;

    public void SetTarget(Transform t) {
        target = t;
    }

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (target && !LevelData.paused) {
            thing = target.position;
            thing.z = zvalue;
            transform.position = Vector3.MoveTowards(transform.position, thing, cameraMoveSpeed);

        }
        
	}
}
