using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour
{
    [SerializeField] private PhysicsMovement movement;
    [SerializeField] private Animator animator;

    [SerializeField] private float turnSpeed = 50f;
    Quaternion rotation = Quaternion.identity;

    Jump isJumping;

    bool hasHorizontalInput;
    bool hasVerticalInput;
    bool isWalking;

    Vector3 movementVector;

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementVector.Set(-verticalInput, 0f, horizontalInput);
        movementVector.Normalize();

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movementVector, turnSpeed * Time.deltaTime, 0f);
        rotation = Quaternion.LookRotation(desiredForward);

        movement.Move(new Vector3(-verticalInput, 0, horizontalInput));
        movement.Rotation(rotation);

        //movement.CheckObstacle();

        hasHorizontalInput = !Mathf.Approximately(horizontalInput, 0f);
        hasVerticalInput = !Mathf.Approximately(verticalInput, 0f);
        isWalking = hasHorizontalInput || hasVerticalInput;
        animator.SetBool("IsWalking", isWalking);
    }
 

}
