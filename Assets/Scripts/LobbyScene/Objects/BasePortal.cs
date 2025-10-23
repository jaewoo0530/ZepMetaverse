using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasePortal : MonoBehaviour, IInteractable
{
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void OnInteract()
    { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("����!");
            if (spriteRenderer != null)
            {
                spriteRenderer.enabled = true;
            }
            else
            {
                Debug.LogWarning("SpriteRenderer�� �� ������Ʈ�� �����ϴ�.", this);
            }
        }
    }

    protected void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
