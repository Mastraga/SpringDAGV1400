using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMover : MonoBehaviour
{
    public float moveSpeed = 5f;
    private CharacterController controller;
    private Transform thisTransform;
    private Vector3 movementVector = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        thisTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCharacter();
        KeepCharacterOnZAxis();
    }

    private void MoveCharacter()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector *= (moveSpeed * Time.deltaTime);
        controller.Move(movementVector);
        if (movementVector.x > 0) transform.rotation = Quaternion.Euler(0, 0, 0);
        if (movementVector.x < 0) transform.rotation = Quaternion.Euler(0, 180, 0);
    }

    private void KeepCharacterOnZAxis()
    {
        var currentPosition = thisTransform.position;
        currentPosition.z = 0f;
        thisTransform.position = currentPosition;
    }
}
