using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_TriggerChangeMaterial : MonoBehaviour {

    public bool rightHand;

    public Material mat;
    public string channel;

    public bool changeFloat;
    public bool changeColor;
    public bool changeVector;
	public bool useButton;
	public bool useAxis;

    public float floatValue;
    public Color colorValue;
    public Vector4 vectorValue;
    public Vector4 vectorLerp;

    float initFloat;
    Color initColor;
    Vector4 initVector;

    float prev = 0;

	public string ctrlName = "TriggerPress";
	string hand;
	public bool debug;


    // Use this for initialization
    void Start () {
		hand = rightHand ? "R" : "L";
        if (changeFloat) {
            initFloat = mat.GetFloat(channel);
        }
        if (changeColor) {
            initColor = mat.GetColor(channel);
        }
        if (changeVector) {
            initVector = mat.GetVector(channel);
        }

    }
	
	// Update is called once per frame
	void Update () {
        GetTrigger();
		DebugTrigger ();
	}

    void GetTrigger() {

		if (Input.GetAxis (hand + ctrlName) > 0 && useAxis)
			Modify (Input.GetAxis (hand + ctrlName));
		else if (Input.GetButton (hand + ctrlName) && useButton)
			Modify (1);
        else if(prev!=0)
            Modify(0);
    }

    Vector4 VLerp(Vector4 a, Vector4 b, Vector4 c) {
        return new Vector4(
            Mathf.Lerp(a.x, b.x, c.x),
            Mathf.Lerp(a.y, b.y, c.y),
            Mathf.Lerp(a.z, b.z, c.z),
            Mathf.Lerp(a.w, b.w, c.w));

    }
    void Modify(float val) {
        if (changeFloat) {
            mat.SetFloat(channel, Mathf.Lerp(initFloat, floatValue,val));
        }
        if (changeColor) {
            mat.SetColor(channel, Color.Lerp(initColor, colorValue, val));
        }
        if (changeVector) {
            mat.SetVector(channel, Vector4.Lerp(VLerp(mat.GetVector(channel), initVector, vectorLerp), VLerp(mat.GetVector(channel), vectorValue, vectorLerp), val));// Vector4.Lerp(VLerp(initVector, vectorLerp), vectorValue, val));
        }
        prev = val;
    }

    void OnDisable() {
        if (changeFloat) {
            mat.SetFloat(channel,initFloat);
        }
        if (changeColor) {
            mat.SetVector(channel,initColor);
        }
        if (changeVector) {
            mat.SetVector(channel,initVector);
        }
    }

	void DebugTrigger() {
		if (debug) {
			if (Input.GetAxis (hand + ctrlName) > 0 && useAxis)
				Debug.Log (hand + ctrlName + " : " + Input.GetAxis (hand + ctrlName));
			if (Input.GetButton (hand + ctrlName) && useButton)
				Debug.Log (hand + ctrlName);
		}
		
	}

    void OnApplicationQuit() {

        OnDisable();
    }
}
