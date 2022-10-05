using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isRunning = false;
    [SerializeField] Animator animator;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }
   
    void Update()
    {
        isRunning = true;   
    }

    private void FixedUpdate()
    {
        if (isRunning)
        {
            CharacterMovement();
            PlayerJump();
        }
    }


    void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("IsRunning", false);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        animator.SetBool("IsRunning", true);
    }
    void CharacterMovement()
    {
        animator.SetBool("IsRunning", true);
    }

}
