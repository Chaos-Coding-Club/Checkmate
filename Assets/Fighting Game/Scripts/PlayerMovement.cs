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
    
    //private Rigidbody2D rb;
    //[SerializeField] private float jumpSpeed = 3f;
    //[SerializeField] private float speedMulitplier = 2f;

    // Start is called before the first frame update
    //void Start()
    //{
    //    //rb = GetComponent<Rigidbody2D>();
    //    //animator = GetComponent<Animator>();
    //}

    // Update is called once per frame
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
        //float dirX = Input.GetAxisRaw("Horizontal");
        //rb.velocity = new Vector2 (dirX * speedMulitplier, rb.velocity.y);

        //if (Input.GetKeyDown("space"))
        //{
        //    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        //}

        //if (Input.GetButtonDown("Fire1"))
        //{
        //    rb.velocity = new Vector2(0, 0);
        //    animator.SetBool("isWalkingForwards", false);
        //    animator.SetBool("isWalkingBackwards", false);
        //    animator.SetBool("isIdle", false);
        //    animator.SetBool("isKicking", true);
        //    Invoke("ResetKick", 0.4f);
        //}

        //if (dirX > 0)
        //{
        //    animator.SetBool("isWalkingBackwards", false);
        //    animator.SetBool("isIdle", false);
        //    animator.SetBool("isKicking", false);
        //    animator.SetBool("isWalkingForwards", true);

        //} else if (dirX < 0) 
        //{
        //    animator.SetBool("isWalkingForwards", false);
        //    animator.SetBool("isIdle", false);
        //    animator.SetBool("isKicking", false);
        //    animator.SetBool("isWalkingBackwards", true);
        //} else if (dirX == 0 && !animator.GetBool("isKicking"))
        //{
        //    animator.SetBool("isWalkingBackwards", false);
        //    animator.SetBool("isWalkingForwards", false);
        //    animator.SetBool("isKicking", false);
        //    animator.SetBool("isIdle", true);
        //}
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
