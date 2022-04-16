using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class PlayerController : Unit
{
    //ENCAPSULATION
    public float moveSpeed { get; private set; } = 2.5f;
    public float jumpHeight { get; private set; } = 425f; 
    private Rigidbody2D playerRb;

    private GameManager gameManager;

    private bool isJumping = false;
    private bool isDoubleJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // POLYMORPHISM
    // Update is called once per frame
    protected override void Update()
    {
        // Call parent class functions (mainly for detecting out of bounds)
        base.Update();

        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);

        // Make player jump if spacebar is pressed and not already jumping. Double jump is allowed, but not more than 1 extra jump
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            playerRb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            isJumping = true;
        } else if (Input.GetKeyDown(KeyCode.Space) && isJumping && !isDoubleJumping)
        {
            playerRb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            isDoubleJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If player collides with enemy while jumping, destroy the enemy
        if (collision.gameObject.CompareTag("Enemy") && isJumping)
        {
            gameManager.UpdateScore(1);
            Destroy(collision.gameObject);
        }
        // If player collides with enemy while not jumping, destroy the player and trigger GameOver state
        else if (collision.gameObject.CompareTag("Enemy") && !isJumping)
        {
            gameManager.GameOver();
            Destroy(gameObject);
        }

        // If the player collides with the ground, set isJumping to false
        if (collision.gameObject.CompareTag("Surface"))
        {
            isJumping = false;
            isDoubleJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // If the player is falling off a platform, count that as a jump so enemies are destroyed (if jumped on)
        if (collision.gameObject.CompareTag("Surface"))
        {
            isJumping = true;
        }
    }
}
