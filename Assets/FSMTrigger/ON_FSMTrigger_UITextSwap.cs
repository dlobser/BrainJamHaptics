﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ON{
	public class ON_FSMTrigger_UITextSwap : ON_FSMTrigger {

		public string text;

		public override void Ping(){
			val.objectToModify.GetComponent<Text> ().text = text;
			for (int i = 0; i < val.objectsToModify.Length; i++) {
				val.objectsToModify[i].GetComponent<Text> ().text = text;
			}
		}
	}
}