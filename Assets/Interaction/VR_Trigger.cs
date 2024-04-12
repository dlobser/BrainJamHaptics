using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class VR_Trigger : MonoBehaviour {


	public bool rightHand;
	public string ctrlName;
    public bool useButton;
    public bool useAxis;

	public string hand { get; set; }
    public float prev { get; set; }

	public bool debug;

    void Start () {
        Setup();
    }


    public virtual void Setup() {

        hand = rightHand ? "R" : "L";
        ctrlName = hand + ctrlName;
        Modify(0);
    }
	
	void Update () {
        GetTrigger();
	}

    public virtual void GetTrigger() {

		if (Input.GetAxis ( ctrlName) > 0 && useAxis)
			Modify (Input.GetAxis (ctrlName));
		else if (Input.GetButton (ctrlName) && useButton)
			Modify (1);
        else if(prev!=0)
            Modify(0);
        DebugTrigger();
    }


    public virtual void Modify(float val) {

    }

    void OnDisable() {
		Modify(0);
    }

	public virtual void DebugTrigger() {
		if (debug) {
            Debug.Log(Input.GetAxis( ctrlName));
			if (Input.GetAxis ( ctrlName) > 0 && useAxis)
				Debug.Log (hand + ctrlName + " : " + Input.GetAxis (ctrlName));
			if (Input.GetButton (ctrlName) && useButton)
				Debug.Log (hand + ctrlName);
		}
	}

    void OnApplicationQuit() {
        OnDisable();
    }
}
