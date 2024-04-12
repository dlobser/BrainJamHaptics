using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using UnityEngine.SceneManagement;

public class VR_TriggerChangeSceneWithLaser : VR_Trigger {

    public LaserPointer laser;

    public override void Modify(float val) {
        if (val > .5f) {
            SceneManager.LoadScene(laser.hit.collider.gameObject.name);
        }
    }

}
