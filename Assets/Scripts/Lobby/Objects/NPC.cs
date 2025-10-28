using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private Camera mainCamera;

    public float normalSize = 7f;
    public float focusSize = 2.5f;
    public float speed = 3f;

    private bool isFocusing = false;

    public virtual void OnInteract()
    {
        StartCoroutine(FocusCamera());
    }

    private IEnumerator FocusCamera()
    {
        while (Mathf.Abs(mainCamera.orthographicSize - focusSize) > 0.01f)
        {
            if (!isFocusing)
            {
                yield break;
            }

            mainCamera.orthographicSize = Mathf.Lerp(
                mainCamera.orthographicSize,
                focusSize,
                Time.deltaTime * speed
            );
            yield return null;
        }

        mainCamera.orthographicSize = focusSize;
    }

    private IEnumerator ReturnCamera()
    {
        while (Mathf.Abs(mainCamera.orthographicSize - normalSize) > 0.01f)
        {
            if (isFocusing)
            {
                yield break;
            }

            mainCamera.orthographicSize = Mathf.Lerp(
                mainCamera.orthographicSize,
                normalSize,
                Time.deltaTime * speed
            );
            yield return null;
        }

        mainCamera.orthographicSize = normalSize;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (canvas != null)
            {
                isFocusing = true;
                canvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (canvas != null)
            {
                isFocusing = false;
                canvas.SetActive(false);
                StartCoroutine(ReturnCamera());
            }
        }
    }
}
