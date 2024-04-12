﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FSM_TouchInteraction : MonoBehaviour , IPointerClickHandler, IPointerEnterHandler{

	public bool UseMouse;
	public bool useObject;
	public string objectName = "Controller (left)";
	public static GameObject rayObject { get; set; }
	public Vector3 hitPosition;
	public static Vector3 theHitPosition;
	public Vector3 hitNormal;
	public GameObject hitObject;
	public static GameObject theHitObject;
	public static bool beenHit;
	GameObject objPos;


	public delegate void MouseHasHit();
	public static event MouseHasHit mouseHasHit;

//	Touch touch = Input.GetTouch(0);

	public void OnPointerEnter(PointerEventData p){
		Debug.Log ("entered");
	}
	public void OnPointerClick(PointerEventData p){
		Debug.Log ("pointed");
	}

	private void Start() {

		rayObject = GameObject.Find(objectName);
		if (rayObject == null && useObject) {
			Debug.LogWarning("ray object not found");
		}
		if (useObject) {
			UseMouse = false;
			Debug.LogWarning ("Can't use object and mouse at the same time");
		}
	}

	void Update() {
//
//		RaycastHit hitInfo = new RaycastHit();
//		bool hit;
//
//		if (UseMouse)
//			hit = Physics.Raycast(Camera.main.ScreenPointToRay(touch.position), out hitInfo);
//		else{
//			if (useObject) {
//				if(rayObject == null || rayObject.name!=objectName) { 
//					rayObject = GameObject.Find(objectName);
//						rayObject = Camera.main.gameObject;
//				}
//				objPos = rayObject;
//
//			}
//			else {
//				objPos = Camera.main.gameObject;
//			}
//			hit = Physics.Raycast(new Ray(objPos.transform.position, objPos.transform.forward), out hitInfo, 1e6f);
//		}
//
//		beenHit = hit;
//
//		if (hit) {
//			//ON.ON_InteractableEvents pinger = hitInfo.transform.gameObject.GetComponent<ON.ON_InteractableEvents>();
//			hitPosition = hitInfo.point;
//			hitNormal = hitInfo.normal;
//			hitObject = hitInfo.collider.gameObject;
//			if (hitInfo.transform.gameObject.GetComponent<ON.ON_FSM> () != null) {
//				if (touch.phase == TouchPhase.Began)
//					hitInfo.transform.gameObject.GetComponent<ON.ON_FSM> ().Trigger ();
//				hitInfo.transform.gameObject.GetComponent<ON.ON_FSM> ().Ping ();
//			}
//			if (hitInfo.transform.gameObject.GetComponent<ON.ON_FSM_Manager> () != null) {
//				if (touch.phase == TouchPhase.Began){
//					Debug.Log (hitInfo);
//					hitInfo.transform.gameObject.GetComponent<ON.ON_FSM_Manager> ().Trigger ();
//				}
//				hitInfo.transform.gameObject.GetComponent<ON.ON_FSM_Manager> ().Ping ();
//			}
//
//		}
//		else {
//			hitPosition = Vector3.zero;
//			hitNormal = Vector3.zero;
//			hitObject = null;
//		}
//
//		theHitPosition = hitPosition;
//		theHitObject = hitObject;
	}
}

