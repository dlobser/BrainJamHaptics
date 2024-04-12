using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_PlayAnimation : Interactable
{
    //explodes an object when clicked

    public Animator animator;
    public string trigger;

    public override void HandleHover()
    {
        if(clicked>.5f){
            HandleTrigger();
        }
    }

	public override void HandleTrigger()
	{
		base.HandleTrigger();
        animator.SetTrigger(trigger);
	}
}
