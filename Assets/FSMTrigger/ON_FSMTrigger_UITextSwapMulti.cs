using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ON{
	public class ON_FSMTrigger_UITextSwapMulti : ON_FSMTrigger {

		public string[] text;
		public float[] times;
		int which;

		public override void Ping(){
			StartCoroutine (Swap ());
		}

		IEnumerator	Swap(){
			for (int i = 0; i < text.Length; i++) {
				float counter = 0;
				while (counter < times [i]) {
					counter += Time.deltaTime;
					yield return new WaitForSeconds (Time.deltaTime);
				}
				val.objectToModify.GetComponent<Text> ().text = text[i];
				yield return null;
			}
			if (times.Length > text.Length) {
				float counter = 0;
				while (counter < times [times.Length - 1] ) {
					counter += Time.deltaTime;
					yield return new WaitForSeconds (Time.deltaTime);
				}
			}
			Reset ();
		}
	}
}