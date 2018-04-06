using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    public SpriteRenderer ballSprite;

    private Rigidbody2D ball;

    private void Awake()
    {
        ball = this.GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        float randomNumber = Random.Range(0, 2);
        if (randomNumber <= 0.5)
        {
            ballSprite.flipX = true;
            ball.AddForce(new Vector2(60, 10));
        }
        else
        {
            ball.AddForce(new Vector2(-60, -10));
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            Rigidbody2D paddle = collision.collider.GetComponent<Rigidbody2D>();

            if (ballSprite.flipX)
            {
                ballSprite.flipX = false;
            }
            else
            {
                ballSprite.flipX = true;
            }

            float velY = ball.velocity.y;
            float velX = ball.velocity.x;
            ball.velocity = new Vector2(velX, velY / 2 + paddle.velocity.y / 3);
        }
        else if (collision.collider.name == "wallTop" || collision.collider.name == "wallBottom")
        {
            if (ballSprite.flipY)
            {
                ballSprite.flipY = false;
            }
            else
            {
                ballSprite.flipY = true;
            }
        }
    }
}
