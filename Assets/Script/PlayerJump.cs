using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private float jumpForce = 6;
    [SerializeField] private Animator _animator;

    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {

            Jump();
        }

        _animator.SetBool("isJumping", !IsGrounded());
    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1.1f, LayerMask.GetMask("Ground"));
    }
    public void Jump()
    {
        rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
