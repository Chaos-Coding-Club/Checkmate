using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Combat : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Update()
    {
        if (Input.GetButtonDown("Fire1P1"))
        {
            Punch();
        }

        if (Input.GetButtonDown("Fire2P1"))
        {
            Kick();
        }

    }

    void Punch()
    {
        animator.SetTrigger("Punch");
    }

    void Kick()
    {
        animator.SetTrigger("Kick");
    }
}
