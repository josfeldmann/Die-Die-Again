﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : BuildingBlock
{
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            LevelData.Instance.WinGame();
        }
    }
}
