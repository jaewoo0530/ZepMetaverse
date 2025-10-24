using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Camera camera;
    private Vector2 direction;

    [SerializeField] private float interactRadius = 0.8f;
    [SerializeField] private LayerMask interactableLayer;

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

        if (Input.GetKeyDown(KeyCode.F))
        {
            TryInteract();
        }
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
        Collider2D hit = Physics2D.OverlapCircle(transform.position, interactRadius, interactableLayer);
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

    // Scene �信�� ���� �ø� ǥ�õ�
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan; // ǥ�� ����
        Gizmos.DrawWireSphere(transform.position, interactRadius); // ���� �ݰ� �ð�ȭ
    }
}
