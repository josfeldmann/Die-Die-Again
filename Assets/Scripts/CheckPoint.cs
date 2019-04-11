using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : BuildingBlock {


	// Use this for initialization
	void Start () {
        if (LevelData.Spawnpoint != this)
            TurnOff();
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnOff() {
        GetComponent<SpriteRenderer>().color = LevelData.Instance.checkPointOffColor;
    }

    public void TurnOn() {
        GetComponent<SpriteRenderer>().color = LevelData.Instance.checkpointOnColor;
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.tag == "Player") {
            LevelData.Spawnpoint.TurnOff();
            LevelData.Spawnpoint = this;
            TurnOn();
        }
    }
}
