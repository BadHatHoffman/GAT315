using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator animator;

    float horizontal = 0f;
    float speed = 40f;
    bool jump = false;
    bool crouch = false;


    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal") * speed;

        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLand()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouch(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    //Move Character
    void FixedUpdate()
    {
        controller.Move(horizontal * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
