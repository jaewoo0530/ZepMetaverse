using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private TopDownManager topDownManager;
    private Camera camera;

    public void Init(TopDownManager topDownManager)
    {
        this.topDownManager = topDownManager;
        camera = Camera.main;
    }


    protected override void HandleAction()
    {
    }

    public override void Death()
    {
        base.Death();
        topDownManager.GameOver();
    }
    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnLook(InputValue inputValue)
    {
        Vector2 mousePosition = inputValue.Get<Vector2>();
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    void OnFire(InputValue inputValue)
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        isAttacking = inputValue.isPressed;
    }
}