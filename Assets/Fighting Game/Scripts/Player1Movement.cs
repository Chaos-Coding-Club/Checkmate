using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;

    [SerializeField] private Animator animator;
    [SerializeField] private float runSpeed = 40f;
    [SerializeField] private CharacterController2D controller;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("HorizontalP1") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("JumpP1"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("CrouchP1"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("CrouchP1"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
