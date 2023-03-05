using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontalMove = 0f;
    private bool jump = false;
    private bool crouch = false;

    [SerializeField] private Animator animator;
    [SerializeField] private float runSpeed = 40f;
    [SerializeField] private CharacterController2D controller;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
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

    //void ResetKick()
    //{
    //    animator.SetBool("isKicking", false);
    //    animator.SetBool("isWalkingForwards", false);
    //    animator.SetBool("isWalkingBackwards", false);
    //    animator.SetBool("isIdle", true);
    //}
}
