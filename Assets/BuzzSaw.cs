using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzSaw : BuildingBlock {
    
    public float rotSpeed = 3;
    
	// Use this for initialization
	void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!LevelData.paused)
       transform.Rotate(0,0,rotSpeed);
	}
}
