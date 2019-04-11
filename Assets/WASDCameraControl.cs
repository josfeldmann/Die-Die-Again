using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDCameraControl : MonoBehaviour {

    public float moveSpeed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal"), moveSpeed * Input.GetAxis("Vertical"), 0);
    }
}
