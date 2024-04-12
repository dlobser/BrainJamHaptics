using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_EnableDisableSetSwapper : Interactable
{
    public Interactable_EnableDisable[] enablers;
    public bool swapper;
    public override void HandleTrigger()
    {
        base.HandleTrigger();
        foreach(Interactable_EnableDisable d in enablers)
        {
            d.swapper = swapper;
        }
    }
}
