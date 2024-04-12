using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ON{
	public class ON_FSMTrigger_PlayAnimation : ON_FSMTrigger{

        public Animator animator;
        public string triggerName;

		public override void Ping() {
            animator.SetTrigger(triggerName);
		}

	}
}