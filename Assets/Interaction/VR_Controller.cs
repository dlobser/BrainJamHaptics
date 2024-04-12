using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VR_Controller : MonoBehaviour {

    public bool rightHand;
    public bool debug;
    Vector3 prev;
    public float speed { get; set; }

    void Start () {
		string[] names = Input.GetJoystickNames();
        foreach (string n in names) {
            Debug.Log(n);
        }

    }

    // Update is called once per frame
    void Update () {
      
        if (rightHand) {
            this.transform.localPosition = InputTracking.GetLocalPosition(XRNode.RightHand);
            this.transform.localRotation = InputTracking.GetLocalRotation(XRNode.RightHand);
        }
        else {
            this.transform.localPosition = InputTracking.GetLocalPosition(XRNode.LeftHand);
            this.transform.localRotation = InputTracking.GetLocalRotation(XRNode.LeftHand);

        }
        // if (this.transform.Find("Ctrls").gameObject.activeInHierarchy && this.transform.position.Equals(Vector3.zero)) {
        //     this.transform.Find("Ctrls").gameObject.SetActive(false);
        // }
        // else if(!this.transform.Find("Ctrls").gameObject.activeInHierarchy && !this.transform.position.Equals(Vector3.zero))
        //     this.transform.Find("Ctrls").gameObject.SetActive(true);

        speed = Mathf.Lerp(speed, Vector3.Distance(prev, this.transform.position), .6f);

        if (debug) {
            GetTrigger(rightHand ? "R" : "L");
            Debug.Log(Vector3.Distance(prev, this.transform.position));
        }
        prev = this.transform.position;
    }
   

    void GetTrigger(string hand) {

        if (Input.GetAxis(hand + "TriggerPress")>0)
            Debug.Log(hand+"Trigger");
        if (Input.GetButton(hand + "PadPress") )
            Debug.Log(hand + "PadPress");
        if (Input.GetButton(hand + "PadTouch"))
            Debug.Log(hand + "PadTouch");

    }
}
