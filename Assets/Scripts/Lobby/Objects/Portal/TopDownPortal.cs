using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownPortal : BasePortal
{
    public override void OnInteract()
    {
        GameManager.Instance.EnterMiniGame("TopDown");
    }
}
