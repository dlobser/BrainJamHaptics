using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Interactable_SetAudioLevel : Interactable
{
    public UnityEngine.Audio.AudioMixer masterMixer;

    public string mixer;
    public float value;

    public override void HandleTrigger()
    {
        bool did = masterMixer.SetFloat(mixer, value);
        float t = 0;
        masterMixer.GetFloat(mixer, out t);
        print(t);


        print("Did: " + did);
    }

}
