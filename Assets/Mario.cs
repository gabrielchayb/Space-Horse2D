using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mario : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rig;
    public Animator anim;
    public float speed;
    public float maxJumpHeight = 5f;
    public float maxJumpTime = 1f;
    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);

    public bool grounded {get; private set;}
    public bool jumping {get; private set;}
    



    private Vector2 direction;
    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal") * speed, rig.velocity.y);

        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            spriteRenderer.flipX = false;
        }

        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        rig.velocity = direction;

        if(direction.sqrMagnitude > 0)
        {
            anim.Play("run");
        }

        else
        {
            anim.Play("idle");
        }

        if(direction.sqrMagnitude > 0)
        {
            anim.Play("run");
        }

        else
        {
            anim.Play("idle");
        }

        if(Input.GetButtonDown("Jump"))
        {
            rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }
    }

      
}
