using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheStackPortal : BasePortal
{
    public override void OnInteract()
    {
        GameManager.Instance.EnterMiniGame(2);
    }
}
