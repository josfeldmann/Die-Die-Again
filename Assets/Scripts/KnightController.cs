using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightController : MonoBehaviour {


    Rigidbody2D[] rigidbody2Ds;
    CapsuleCollider2D[] capCollider2Ds;
    HingeJoint2D[] HingeJoint2Ds;
    Animator anim;

    public bool debugObj;
    Rigidbody2D rb;
    bool dead;

    GameObject PlayerSpawnpoint;

	// Use this for initialization
	void Start () {
        Camera.main.GetComponent<CameraController>().SetTarget(transform);
        anim = GetComponent<Animator>();
        rigidbody2Ds = GetComponentsInChildren<Rigidbody2D>();
        capCollider2Ds = GetComponentsInChildren<CapsuleCollider2D>();
        HingeJoint2Ds = GetComponentsInChildren<HingeJoint2D>();
        rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(!debugObj);


    }

    public void ActivateRagdoll() {
        anim.enabled = false;
        rb.mass = 5;
        foreach (Rigidbody2D rb in rigidbody2Ds) {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
        foreach (HingeJoint2D rb in HingeJoint2Ds) {
            rb.enabled = true;
        }
        foreach (CapsuleCollider2D rb in capCollider2Ds) {
            rb.enabled = true;
            gameObject.tag = "Untagged";
            //rb.gameObject.layer = 12;
        }

        
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().freezeRotation = false;
        GetComponent<BoxCollider2D>().enabled = true;
        Destroy(GetComponent<CharacterController2D>());
        LevelData.Instance.PlayerDied();
        dead = true;
        transform.gameObject.layer = 12;
        Destroy(this);
    }

    // Update is called once per frame
    void Update () {
		
      

	}

    public void OnCollisionEnter2D(Collision2D col) {
        if (col.transform.tag == "Death") {
            if (!dead)
            ActivateRagdoll();
        }
    }

    public void OnTriggerEnter2D(Collider2D col) {
        if (col.transform.tag == "Death") {
            if (!dead)
                ActivateRagdoll();
        }
    }
}
