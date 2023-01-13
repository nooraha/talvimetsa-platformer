using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class CharaMovement : MonoBehaviour
{
    private Rigidbody2D body;

    public float reverseCooldownTime = 2;
    public float nextReverseTime = 0;

    public Animator animator;

    private bool grounded;
    public bool reversed;


    private double xscale = 0.2;
    private double yscale = 0.2;

    public CooldownBar myCooldownBar;

    [SerializeField] private float speed;
    [SerializeField] private float jumppower;

    [SerializeField] private LayerMask platformLayer;
    private Transform platform;
    private bool isOnThePlatform = false;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        Reverse();
        nextReverseTime = Time.time + reverseCooldownTime;
        myCooldownBar.SetMaxCooldown(reverseCooldownTime);

        this.platform = null;
    }

    private void Update()
    {

        if(nextReverseTime - Time.time >= 0)
        myCooldownBar.SetCooldown(nextReverseTime - Time.time);

        //movement
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);


        //flip player when moving
        if(horizontalInput > 0.01f)
        {
            xscale = 0.2;
        }
        else if(horizontalInput < -0.01f)
        {
            xscale = -0.2;
        }


        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));

        //flip player when reversing
        if(reversed == true)
        {
            yscale = 0.2;
        }
        else
        {
            yscale = -0.2;
        }

        transform.localScale = new Vector3((float)xscale, (float)yscale, transform.localScale.z);

        //reverse mechanic
        if (Input.GetKey(KeyCode.B) && grounded && Time.time > nextReverseTime)
        {
            Reverse();
            nextReverseTime = Time.time + reverseCooldownTime;
            animator.SetBool("IsJumping", true);
        }

        //jump
        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
            animator.SetBool("IsJumping", true);
        }

        

        if (platform != null) transform.parent = platform;
        else                  transform.parent = null;

        if (isOnThePlatform) isOnThePlatform = IsOnPlatform();

        
    }

    private bool IsOnPlatform()
    {
        RaycastHit2D hit = Physics2D.BoxCast(transform.localPosition, transform.localScale, 0, Vector2.down, 0.1f, platformLayer);
        if (hit && isOnThePlatform) isOnThePlatform = true;
        if (hit) this.platform = hit.collider.gameObject.transform;
        else this.platform = null;
        return hit.collider != null;
    }

    private void Reverse()
    {
        //turn gravity upside down
        if (reversed == true)
        {
            body.gravityScale = -2;
            jumppower = -10;
            
            reversed = false;
        }
        else
        {
            jumppower = 10;
            body.gravityScale = 2;

            reversed = true;
        }

    }
    private void Jump()
    {
            body.velocity = new Vector2(body.velocity.x, jumppower);
            grounded = false;
    }

    //grounded
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
            animator.SetBool("IsJumping", false);
        }
    }

}
