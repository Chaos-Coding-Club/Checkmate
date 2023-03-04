using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2 (dirX * 7f, rb.velocity.y);

        if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector2(rb.velocity.x, 3f);
        }

        if (dirX > 0)
        {
            animator.SetBool("isWalking", true);
        } else if (dirX < 0) {
            animator.SetBool("isWalking", true);
        } else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
