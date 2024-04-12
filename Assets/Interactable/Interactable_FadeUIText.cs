using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable_FadeUIText : Interactable
{

    public bool click;
    public bool clickable = true;
    public Text text;
    
    public override void HandleHover()
    {
        base.HandleHover();
        if (debug)
        {
            print(this.gameObject.name + ": " + clicked);
        }
        if (clicked > .5f && !click && clickable)
        {
            click = true;
            StartCoroutine(Fade());
        }

        if (clicked < .5f && !clickable)
        {
            clickable = true;
        }

    }

    public override void HandleExit()
    {
        base.HandleExit();
        //PointerEventData data = new PointerEventData(EventSystem.current);
        //button.OnPointerExit(data);
        clickable = true;
        click = false;
        clicked = 0;
    }

    private void OnDisable()
    {
        Color col = text.color;
        text.color = new Color(col.r, col.g, col.b, 0);
    }

    IEnumerator Fade()
    {
        float count = 1;
        Color col = text.color;
        while (count > 0)
        {
            count -= Time.deltaTime*.3333f;
            text.color = new Color(col.r, col.g, col.b, count);
            yield return null;
        }
    }
}
