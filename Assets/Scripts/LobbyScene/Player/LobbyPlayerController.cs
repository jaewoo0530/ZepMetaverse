using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Camera camera;
    private Vector2 direction;

    private LayerMask interactable;

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
        TryInteract();
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
        if(direction.x < 0)
        {
            characterRenderer.flipX = true;
        }
        else if(direction.x > 0)
        {
            characterRenderer.flipX = false;
        }
    }

    private void TryInteract()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            interactable = LayerMask.GetMask("Interactable");
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, 1f, interactable);
            if (hit.collider != null)
            {
                hit.collider.GetComponent<IInteractable>()?.OnInteract();
            }
        }
    }
}
