using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPlayer : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Camera camera;
    private Vector2 direction;

    [SerializeField] private SpriteRenderer characterRenderer;

    public float playerSpeed = 5f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        Rotate();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector2(horizontal, vertical).normalized;

        rigidbody.velocity = direction * playerSpeed;
    }

    private void Rotate()
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;
    }
}
