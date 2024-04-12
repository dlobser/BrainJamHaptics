using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_EnableDisableHover : Interactable
{
    public GameObject[] enable;
    public GameObject[] disable;
    public bool swap;
    public bool swapper;
    bool triggered;
    public bool click;
    public bool clickable = true;
    ON.Button button;

    // Update is called once per frame
    public override void HandleUpdate() {
        base.HandleUpdate();
        if (click && clickable) {
            click = false;
            clickable = false;
            foreach (GameObject g in enable)
                if (g != null)
                    g.SetActive(swapper ? true : false);
            foreach (GameObject g in disable)
                if (g != null)
                    g.SetActive(swapper ? false : true);
        }
    }


    public override void HandleExit() {
        base.HandleExit();
        clickable = true;
        click = false;
        clicked = 0;
    }

    public override void HandleHover() {
        base.HandleHover();
        if (clicked > .5f && !click && clickable) {
            click = true;

        }
        if (clicked < .5f && !clickable) {
            clickable = true;
        }
    }

    
}
