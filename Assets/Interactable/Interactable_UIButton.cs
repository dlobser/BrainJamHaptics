using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Interactable_UIButton : Interactable
{
    public Button button;
    public bool click;
    public bool clickable = true;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    public override void HandleUpdate()
    {
        base.HandleUpdate();
        if (click && clickable)
        {
            PointerEventData data = new PointerEventData(EventSystem.current);
            data.eligibleForClick = true;
            data.clickCount = 1;
            button.OnPointerClick(data);
            click = false;
            clickable = false;
        }
    }

    public override void HandleEnter() {
        base.HandleEnter();
        if (clicked > .5f)
        {
            clickable = false;
        }
        //PointerEventData data = new PointerEventData(EventSystem.current);
        //button.OnPointerExit(data);
        if (GetComponent<HapticTransmitter>() != null)
            GetComponent<HapticTransmitter>().HandleTrigger();
    }

    public override void HandleExit() {
        base.HandleExit();
        //PointerEventData data = new PointerEventData(EventSystem.current);
        //button.OnPointerExit(data);
        clickable = true;
        click = false;
        clicked = 0;
    }

    public override void HandleHover()
    {
        base.HandleHover();
        //print(clicked);
        //print("gaze" + gaze.button.click);
        if (clicked > .5f && !click && clickable)
        {
            click = true;
            
        }
        if(clicked<.5f && !clickable)
        {
            clickable = true;
        }
    }
}
