using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour {

    public float walkForceSpeed = 20;
    public Rigidbody2D body;
    public InputManager manager;
    public bool jump = false;
    public float horizontal = 0;
    public float jumpForce = 200f;

    private void Awake() {
       
    }

   

    private void Update() {

        if (!jump && manager.jump) {
            jump = true;
        }

      
    }

    private void FixedUpdate() {
        body.AddForce(new Vector2(manager.horizontal * walkForceSpeed, 0));

        if (jump) {
            body.AddForce(new Vector3(0, jumpForce));
        }

        jump = false;
    }



}
