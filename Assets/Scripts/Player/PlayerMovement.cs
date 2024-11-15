using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Speed and rotation speed variables
    public float moveSpeed = 5f;
    public float rotationSpeed = 700f;

    // Rigidbody to apply physics
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Rigidbody component attached to the player
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input from player (W, A, S, D or Arrow Keys)
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Move the player (using Vector3)
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + movement);

        // Rotate the player to face the direction of movement
        if (movement.magnitude > 0f)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
