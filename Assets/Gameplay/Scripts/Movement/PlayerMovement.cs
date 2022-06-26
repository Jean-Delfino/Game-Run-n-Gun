using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CreatureMoveAndAnimator{
    [SerializeField] float moveSpeed = default;
    [SerializeField] float jumpSpeed = default;
    private bool isJumping;

    private float move;
    private Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

	void Update () {
        move = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (move < 0){
            transform.eulerAngles = new Vector3(0, 180, 0);
        }else if (move > 0){
            transform.eulerAngles = new Vector3(0, 0, 0);
        } 

        if(Input.GetButtonDown("Jump") && !isJumping){
            rb.AddForce(new Vector2(rb.velocity.x, jumpSpeed));
            isJumping = true;
        }

        MovementAnimation(moveSpeed, isJumping);
	}

    public override void DyingAnimation(bool state){
        anim.SetBool("Dead", state);
    }

    public override void MovementAnimation(float walkSpeed, bool jump){
        anim.SetFloat("Movement", Mathf.Abs(walkSpeed));
        anim.SetBool("Jump", jump);
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Ground")){
            isJumping = false;
        }
    }
}
