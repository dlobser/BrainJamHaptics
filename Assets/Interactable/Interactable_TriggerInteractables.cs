using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_TriggerInteractables : Interactable
{
    public Interactable[] trigger;
    public bool swap;
    public bool swapper;

    public override void HandleTrigger()
    {
        base.HandleTrigger();
        foreach (Interactable g in trigger)
            if (swapper) g.HandleTrigger();
        if (swap)
            swapper = !swapper;
    }
}
