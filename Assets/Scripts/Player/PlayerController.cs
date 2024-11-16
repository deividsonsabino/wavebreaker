using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator animator; // Referência ao Animator
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 moveInput;
    private CharacterController characterController;
    private string currentAnimation = "";

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void ChangeAnimation(string animation, float crossFade = 0.2f)
    {
        if (currentAnimation != animation)
        {
            currentAnimation = animation;
            animator.CrossFade(animation, crossFade);
        }
    }

    void Update()
    {
        // Movimento
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y).normalized;
        characterController.Move(move * moveSpeed * Time.deltaTime);
        CheckAnimation();

    }

    private void CheckAnimation()
    {
        if (moveInput.y == 1)
            ChangeAnimation("Walking");
        else
        {
            ChangeAnimation("Idle");
        }
    }
}
