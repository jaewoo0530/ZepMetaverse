using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerFlappyPlane : MonoBehaviour
{
    Animator animator = null;
    Rigidbody2D rigidbody = null;
    Collider2D collider2D = null;

    public float flapForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    private float deathCooldown = 0f;

    private bool isFlap = false;

    private GameManager gameManager;

    void Start()
    {
        animator = transform.GetComponentInChildren<Animator>();
        rigidbody = transform.GetComponent<Rigidbody2D>();
        collider2D = transform.GetComponentInChildren<Collider2D>();
        gameManager = GameManager.Instance;
    }

    void Update()
    {
        if (isDead)
        {
            collider2D.enabled = false;

            if (deathCooldown <= 0)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.flappyPlaneModule.RestartGame();
                }
                else if (Input.GetKeyDown(KeyCode.Escape))
                {
                    gameManager.flappyPlaneModule.ExitGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                isFlap = true;
            }
        }
    }

    public void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;
            isFlap = false;
        }

        rigidbody.velocity = velocity;

        float angle = Mathf.Clamp((rigidbody.velocity.y * 10f), -90, 90);
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (isDead)
            return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetBool("IsDie", true);
        gameManager.flappyPlaneModule.GameOver();
    }
}
