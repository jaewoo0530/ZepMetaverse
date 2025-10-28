using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasePortal : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject canvus;

    public virtual void OnInteract()
    { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("����!");
            if (canvus != null)
            {
                canvus.SetActive(true);
            }
            else
            {
                Debug.LogWarning("SpriteRenderer�� �� ������Ʈ�� �����ϴ�.", this);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (canvus != null)
            {
                canvus.SetActive(false);
            }
        }
    }
}
