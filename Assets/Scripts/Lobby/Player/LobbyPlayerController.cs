using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyPlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Vector2 direction;

    [SerializeField] private float interactRadius = 0.8f;
    [SerializeField] private LayerMask interactableLayer;

    [SerializeField] private SpriteRenderer characterRenderer;

    public float playerSpeed = 5f;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        transform.position = GameManager.Instance.lobbyModule.savedPosition;
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

    // Scene 뷰에서 선택 시만 표시됨
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan; // 표시 색상
        Gizmos.DrawWireSphere(transform.position, interactRadius); // 감지 반경 시각화
    }

    public void SavePoint()
    {
        GameManager.Instance.lobbyModule.savedPosition = transform.position;
    }
}
