using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_OpenURL : Interactable
{
    public string url ="http://cosmicsugarvr.com";

    public override void HandleHover() {
        base.HandleHover();
        if (clicked > .5f) {
            HandleTrigger();
        }
    }
    public override void HandleTrigger()
    {
        base.HandleTrigger();
        Application.OpenURL(url);
    }
}
