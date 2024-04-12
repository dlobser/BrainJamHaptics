using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable_Event : Interactable
{

    public UnityEvent uEvent;
    public bool click;
    public bool clickable = true;
    public bool transmitHaptics;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    public override void HandleUpdate() {
        base.HandleUpdate();
        if (click && clickable) {
            uEvent.Invoke();
            click = false;
            clickable = false;
        }
    }

    public override void HandleEnter() {
        base.HandleEnter();
        if (clicked > .5f) {
            clickable = false;
        }

        if (transmitHaptics && GetComponent<HapticTransmitter>() != null)
            GetComponent<HapticTransmitter>().HandleTrigger();
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
