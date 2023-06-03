using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamera : MonoBehaviour
{
    // The camera attached to the player
    public Camera playerCamera;

    // Container variables for the mouse delta values each frame
    public float deltaX;
    public float deltaY;

    // Container variables for the player's rotations arounf the x and Y axis
    public float xRot; // rotation around the x-axis in degree
    public float yRot; // rotation around the y-axis in degrees 
    

    // Start is called before the first frame update
    void Start()
    {
        playerCamera = Camera.main; // set player camera
        Cursor.visible = false; // hide the cursor
    }

    // Update is called once per frame
    void Update()
    {
        // Keep track of the player's c and y rotation
        yRot += deltaX;
        xRot -= deltaY;

        // keep the player's x rotation clamped to [-90, 90] degrees
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        // rotate the camera arou the x-axis
        playerCamera.transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }

    // onCameraLook event handler
    public void onCameraLook(InputValue value)
    {
        // Reading the mouse deltas as a vector 2 (delta x is the x component and delta y is the y component of the vector)
        Vector2 inputVector = value.Get<Vector2>();
        deltaX = inputVector.x;
        deltaY = inputVector.y;
    }
}
