using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rgbd;
    private Animator anime;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private float dist;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 7f;

    private enum MState {Idle, Run, Jump, Land }
    [SerializeField] private AudioSource jumpSound;
     
    // Start is called before the first  frame update
    private void Start()
    {
       rgbd = GetComponent<Rigidbody2D>();
       coll = GetComponent<BoxCollider2D>();
       anime = GetComponent<Animator>();
       sprite = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    private void Update()
    {
        dist = Input.GetAxisRaw("Horizontal");
        rgbd.velocity = new Vector2(dist*moveSpeed,rgbd.velocity.y);

        if(Input.GetButtonDown("Jump") && isGrounded() )
        {
            jumpSound.Play();
            rgbd.velocity = new Vector2(rgbd.velocity.x,jumpForce);
        }
        AnimUpdate ();

    }


    private void AnimUpdate () 
    {
        MState state;
        if (dist > 0f)
        {
            state = MState.Run;
            sprite.flipX = false;
        }
        else if (dist < 0f)
        {
            state = MState.Run;
            sprite.flipX = true;
        }
        else
        {
            state = MState.Idle;
        }

        if (rgbd.velocity.y > .1f)
        {
            state = MState.Jump;
        }
        if (rgbd.velocity.y < -.1f)
        {
            state = MState.Land;
        }


        anime.SetInteger("state",(int)state);       
    }

    private bool isGrounded(){
       return Physics2D.BoxCast(coll.bounds.center,coll.bounds.size,0f,Vector2.down, .1f, jumpableGround);
    }
}
