using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Flip : Interactable
{
    public bool triggered = false;
    public bool left;
    public float angle;
    public Transform target;
    bool spinning = false;
    bool dontTrigger = false;

    public override void HandleHover() {
        base.HandleHover();
        if (clicked > .5f && !triggered && !dontTrigger) {
            triggered = true;
            StartCoroutine(Rot(left));
        }
    }

    public override void HandleEnter() {
        base.HandleEnter();
        if (clicked > .5f && !triggered) {
            dontTrigger = true;
        }
    }

    public override void HandleExit() {
        base.HandleExit();
        dontTrigger = false;
        
    }

    private void OnDisable()
    {
        if (spinning)
        {
            target.transform.localEulerAngles = Vector3.zero;
            spinning = false;
            triggered = false;
        }
    }

    IEnumerator Rot(bool left) {
        spinning = true;
        float count = 0;
        float y = target.transform.localEulerAngles.y;
        float ny = y + angle;
        while (count < 1) {
            count += Time.deltaTime * 2;
            float cc = (Mathf.Cos(count*Mathf.PI)*-.5f)+.5f;
            float oy = Mathf.Lerp(y, ny, cc);

            target.transform.localEulerAngles = new Vector3(target.transform.localEulerAngles.x, oy, target.transform.localEulerAngles.z);
            yield return null;
        }
        triggered = false;
        spinning = false;
    }
}
