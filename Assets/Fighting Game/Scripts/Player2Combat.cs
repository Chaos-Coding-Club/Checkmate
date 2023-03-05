using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Combat : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void Update()
    {
        if (Input.GetButtonDown("Fire1P2"))
        {
            Punch();
        }

        if (Input.GetButtonDown("Fire2P2"))
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
