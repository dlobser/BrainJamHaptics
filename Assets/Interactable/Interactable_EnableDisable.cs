﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_EnableDisable : Interactable
{
    public GameObject[] enable;
    public GameObject[] disable;
    public bool swap;
    public bool swapper;

	public override void HandleExit()
	{
        foreach (GameObject g in enable)
            if(g!=null)
                g.SetActive(swapper ? true : false);
        foreach (GameObject g in disable)
            if (g != null)
                g.SetActive(swapper ? false : true);
    }
    public void Swap()
    {
        swapper = !swapper;
    }
    public override void HandleEnter()
	{
        foreach (GameObject g in enable)
            if (g != null)
                g.SetActive(swapper?false:true);
        foreach (GameObject g in disable)
            if (g != null)
                g.SetActive(swapper?true:false);
        if (swap)
            swapper = !swapper;
	}

    public override void HandleTrigger()
    {
        //print("Doit");
        base.HandleTrigger();
        HandleEnter();
    }
}
