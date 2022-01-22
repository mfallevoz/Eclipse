using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;

    private bool isJumping;
    private float mouvementSpeed;
    private float mouvementHorizontal;
    private float mouvementVertical;
    private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();

        mouvementSpeed = 3f;
        isJumping = false;
        jumpForce = 60f;
    }

    // Update is called once per frame
    void Update()
    {
        mouvementHorizontal = Input.GetAxisRaw("Horizontal");
        mouvementVertical = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        if (mouvementHorizontal > 0.1f || mouvementHorizontal < -0.1f) {
            rb2D.AddForce(new Vector2(mouvementHorizontal * mouvementSpeed, 0f), ForceMode2D.Impulse);
        }
        if (mouvementVertical > 0.1f && !isJumping) {
            rb2D.AddForce(new Vector2(0f, mouvementVertical * jumpForce), ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            isJumping = true;
        }
    }
}
