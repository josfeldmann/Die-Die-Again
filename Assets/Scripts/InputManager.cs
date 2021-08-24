using UnityEngine;

public class InputManager : MonoBehaviour {

    public float horizontal;
    public bool jump = false;

    private void Update() {
        horizontal = Input.GetAxis("Horizontal");
        jump = Input.GetKeyDown(KeyCode.Space);
    }


}