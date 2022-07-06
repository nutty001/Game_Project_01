using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    private float dirX = 0f;
    [SerializeField] private float movespeed = 5f;
    [SerializeField] private float jumpforce = 7f;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * movespeed,rb.velocity.y);

         if(Input.GetKey("space"))
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpforce);
        } 

        UpdateAnimationUpdate();
    }

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
