using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyPlanePortal : BasePortal
{
    public override void OnInteract()
    {
        ChangeScene(1);
    }
}
