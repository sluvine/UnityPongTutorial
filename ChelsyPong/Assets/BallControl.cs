using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

    public SpriteRenderer ballSprite;

    public float ballSpeed = 80;

    public AudioClip wallHitSound;
    public AudioClip playerHitSound;
    public AudioClip playerMissSound;
    public AudioClip goalSound;

    private Rigidbody2D ball;

    private void Awake()
    {
        ball = this.GetComponent<Rigidbody2D>();
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(WaitToStartBall());
        GetComponent<AudioSource>().playOnAwake = false;
	}

    IEnumerator WaitToStartBall()
    {
        yield return new WaitForSeconds(2);
        GoBall();
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

            GetComponent<AudioSource>().clip = playerHitSound;
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
            GetComponent<AudioSource>().Play();
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

            GetComponent<AudioSource>().clip = wallHitSound;
            GetComponent<AudioSource>().Play();
        }

    }

    private void GoBall()
    {
        float randomNumber = Random.Range(0, 2);
        if (randomNumber <= 0.5)
        {
            ballSprite.flipX = true;
            ball.AddForce(new Vector2(ballSpeed, 10));
        }
        else
        {
            ball.AddForce(new Vector2(-ballSpeed, -10));
        }
    }

    private void ResetBall()
    {
        GetComponent<AudioSource>().clip = playerMissSound;
        GetComponent<AudioSource>().Play();

        GetComponent<AudioSource>().clip = goalSound;
        GetComponent<AudioSource>().Play();

        ball.velocity = new Vector2(0, 0);
        ball.position = new Vector2(0, 0);
        ballSprite.flipX = false;
        ballSprite.flipY = false;

        StartCoroutine(WaitToStartBall());
    }
}
