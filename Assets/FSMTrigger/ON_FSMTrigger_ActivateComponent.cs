
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ON{
	public class ON_FSMTrigger_ActivateComponent: ON_FSMTrigger{

		public enum comp{Collider,Renderer, FSM_Manager};
		public comp component;

		public bool findInHierarchy;
		public string[] Activate;
		public string[] Deactivate;
		public GameObject[] activate;
		public GameObject[] deactivate;
		public bool swapActiveDeactive;
		public bool populateFromStrings;

		Collider collider;
		Renderer renderer;
		ON_FSM_Manager_Events manager;

		void Start(){
			SetupObject ();
			if(populateFromStrings)
				FillGOArray ();
		}

		void FillGOArray(){
			activate = new GameObject[Activate.Length];
			deactivate = new GameObject[Deactivate.Length];
//			Debug.Log (val.objectToModify);
			if (findInHierarchy) {
				for (int i = 0; i < activate.Length; i++) {
					activate [i] = FindInHierarchy (val.objectToModify.transform, Activate [i]).gameObject;// val.objectToModify.GetComponent<ON_GameObjectSelector> ().Find (Activate [i]);
				}
				for (int i = 0; i < deactivate.Length; i++) {
					deactivate [i] = FindInHierarchy (val.objectToModify.transform, Deactivate [i]).gameObject;//val.objectToModify.GetComponent<ON_GameObjectSelector> ().Find (Deactivate [i]);
				}
			} else {
				for (int i = 0; i < activate.Length; i++) {
					activate [i] = GameObject.Find (Activate [i]);
				}
				for (int i = 0; i < deactivate.Length; i++) {
					deactivate [i] =  GameObject.Find (Deactivate [i]);
				}
			}
		}

		void ActivateComponent(GameObject g, bool enabled){

			switch(component){
				case comp.Collider:
					g.GetComponent<Collider> ().enabled = enabled;
					break;
				case comp.Renderer:
					g.GetComponent<Renderer> ().enabled = enabled;
					break;
				case comp.FSM_Manager:
					g.GetComponent<ON_FSM_Manager_Events> ().enabled = enabled;
					break;
			}
		}

		public override void Ping() {
//			if (useGameObjectSelector) {
//				activate = val.objectToModify.GetComponent<ON_GameObjectSelector> ().A;
//				deactivate = val.objectToModify.GetComponent<ON_GameObjectSelector> ().B;
//			}
			if (activate.Length>0 && activate [0] == null || deactivate.Length>0 && deactivate [0] == null)
				if(populateFromStrings)
						FillGOArray ();
			for (int i = 0; i < activate.Length; i++) {
				ActivateComponent (activate [i], !swapActiveDeactive);// activate [i].SetActive (!swapActiveDeactive);
			}
			for (int i = 0; i < deactivate.Length; i++) {
				ActivateComponent (deactivate [i], swapActiveDeactive);//deactivate [i].SetActive (swapActiveDeactive);
			}
		}

	}
}