using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_PlaySound : Interactable
{
    public AudioSource sound;
    public AudioClip clip;
    public float randomizePitch = 0;
    public bool triggerOnAudioEnd = false;
    public Interactable[] interactables;
    float counter;
    public float length;
    public bool playIfPlaying = false;
    bool triggered;

	public override void HandleEnter()
	{
        base.HandleEnter();

        Interactable_PlaySound[] playSounds = FindObjectsOfType<Interactable_PlaySound>();
        foreach (Interactable_PlaySound p in playSounds)
        {
            p.triggered = false;
            p.counter = 0;
        }

        if (clip != null)
            sound.clip = clip;
        if(length<=0)
            length = sound.clip.length;
        triggered = true;
        if (!sound.isPlaying || playIfPlaying)
        {
            counter = 0;
            sound.pitch = Random.Range(1 - randomizePitch, 1 + randomizePitch);
            sound.Play();
        }

    }

    public override void HandleTrigger()
    {

        base.HandleTrigger();
        //triggered = true;
        //if (clip != null)
        //    sound.clip = clip;
        //if (length <= 0)
        //    length = sound.clip.length;
        //if (!sound.isPlaying || playIfPlaying)
        //{
        //    counter = 0;
        //    sound.pitch = Random.Range(1 - randomizePitch, 1 + randomizePitch);
        //    sound.Play();
        //}
    }

    public override void HandleExit()
    {
        base.HandleExit();
        //triggered = false;
        //counter = 0;
    }

    public override void HandleUpdate()
    {
        base.HandleUpdate();
        if (triggerOnAudioEnd && triggered)
        {
            counter += Time.deltaTime;
            if (counter >= length)
            {
                counter = 0;
                foreach(Interactable i in interactables)
                {
                    i.HandleTrigger();
                }
            }
        }
    }
}