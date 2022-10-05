using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] Animator animator;
    
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        CharacterMovement();
        PlayerJump();        
    }


    void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SoundManager.Instance.Play(SoundManager.Sounds.PlayerJump);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    void CharacterMovement()
    {
        animator.SetBool("IsRunning", true);
    }

}
