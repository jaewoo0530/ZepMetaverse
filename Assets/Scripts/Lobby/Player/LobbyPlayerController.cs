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
        characterRenderer.sortingOrder = 100 - (int)transform.position.y;
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
        float radius = 0.8f;
        int interactableLayer = LayerMask.GetMask("Interactable");

        // 디버깅용으로 반경 표시
        DebugDrawCircle(transform.position, radius, Color.cyan);

        if (Input.GetKeyDown(KeyCode.F))
        {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, radius, interactableLayer);
            if (hit != null)
            {
                Debug.Log($"Interact with {hit.name}");
                hit.GetComponent<IInteractable>()?.OnInteract();
            }
            else
            {
                Debug.Log("No interactable object nearby");
            }
        }
    }

    private void DebugDrawCircle(Vector3 center, float radius, Color color)
    {
        int segments = 20;
        float angle = 0f;
        Vector3 prevPoint = center + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
        for (int i = 1; i <= segments; i++)
        {
            angle = i * Mathf.PI * 2 / segments;
            Vector3 nextPoint = center + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
            Debug.DrawLine(prevPoint, nextPoint, color);
            prevPoint = nextPoint;
        }
    }
}
