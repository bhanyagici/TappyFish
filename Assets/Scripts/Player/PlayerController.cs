using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField]
    private float flySpeed;
    int angle;
    int maxAngle = 20;
    int minAngle = -60;
    public ScoreManager score;
    bool touchedGround;
    public GameManager gameManager;
    public Sprite fishDied;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public ObstacleSpawner obstacleSpawner;
    [SerializeField] private AudioSource swim,hit,point;
    

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        FishSwimInput();
    }


    void FixedUpdate()
    {
        FishRotation();
    }


    void FishSwimInput()
    {

        if (Input.GetMouseButtonDown(0) && GameManager.gameOver == false)
        {
            swim.Play();
            if (GameManager.gameStarted == false)
            {
                _rigidbody.gravityScale = 3f;
                _rigidbody.velocity = Vector2.zero;
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, flySpeed);
                obstacleSpawner.InstantiateObstacle();
                gameManager.GameHasStarted();
            }
            
            else
            {
                _rigidbody.velocity = Vector2.zero;
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, flySpeed);
            }
           
        }

    }


    void FishRotation()
    {

        if (_rigidbody.velocity.y > 0)
        {
            if (angle <= maxAngle)
            {
                angle = angle + 4;
            }
        }

        else if (_rigidbody.velocity.y < -1.2)
        {
            if (angle > minAngle)
            {
                angle = angle - 2;
            }
        }

        if (touchedGround == false)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            //Debug.Log("Scored");
            score.Scored();
            point.Play();
        }

        else if (collision.CompareTag("Column") && GameManager.gameOver == false)
        {
            // game over
            FishDieEffect();
            gameManager.GameOver();
        }
    }


    void FishDieEffect()
    {
        hit.Play();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (GameManager.gameOver == false)
            {
                //gameover
                FishDieEffect();
                gameManager.GameOver();
                GameOver();
            }

            else
            {
                //gameover fish
                GameOver();
            }
        }
    }


    void GameOver()
    {
        touchedGround = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        spriteRenderer.sprite = fishDied;
        animator.enabled = false;
    }




}
