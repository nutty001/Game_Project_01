using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformlayerMask;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;
    private BoxCollider2D boxCollider2d;

    private float dirX = 0f;
    [SerializeField] private float movespeed = 5f;
    [SerializeField] private float jumpforce = 3f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //Horizontal run
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * movespeed,rb.velocity.y);

        //Jump
         if(IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpforce);
        } 

        UpdateAnimationUpdate();
    }

    private bool IsGrounded() {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 1f,platformlayerMask);
        Debug.Log(raycastHit2d.collider);
        return raycastHit2d.collider != null;
    }
    //Animation
    private void UpdateAnimationUpdate()
    {
          if(dirX > 0f)
        {
            anim.SetBool("Running",true);
            sprite.flipX = false;
        }
        else if(dirX < 0f)
        {
            anim.SetBool("Running",true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("Running",false);
        }
    }
}
