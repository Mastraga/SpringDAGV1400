using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = -9.81f;

    private CharacterController controller;
    private Transform thisTransform;
    private Vector3 movementVector = Vector3.zero;
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(controller.isGrounded + "Start of Update");
        
        MoveCharacter();
        ApplyGravity();
        KeepCharacterOnZAxis();
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
        //Debug.Log(controller.isGrounded + "End of Update");
    }

    private void MoveCharacter()
    {
        //Debug.Log(controller.isGrounded + "Before MoveCharacter"); //On the ground
        var moveInput = Input.GetAxis("Horizontal");
        var move = new Vector3 (moveInput, 0.0f, 0.0f) * (moveSpeed * Time.deltaTime);
        controller.Move(move);
        //Debug.Log(controller.isGrounded + "After MoveCharacter");  //No longer on the ground??

        //It might be that something about the Move() function temporarily takes the character controller off the ground

        if (moveInput > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        if (moveInput < 0) transform.rotation = Quaternion.Euler(0, 180, 0);

        // Jumping
        /*if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }*/
       
    }

    private void KeepCharacterOnZAxis()
    {
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }

    private void ApplyGravity()
    {
        //controller.Move(velocity * Time.deltaTime);
        if (!controller.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            
        }
        else
        {
            velocity.y = 0f;
            
        }
        controller.Move(velocity * Time.deltaTime);
        
        Debug.Log(velocity.y);
        
        
    }
}
