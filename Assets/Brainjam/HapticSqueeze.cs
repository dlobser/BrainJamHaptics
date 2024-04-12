using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticSqueeze : MonoBehaviour
{
    public float frequency;
    public float amplitude;
    public float fadeSpeed;

    bool hovering;


    public bool vibrato;
    [Tooltip("X:frequency Y:Low Z:High")]
    public Vector4 vibratoData;
    float vibratoAmplitude;
    public float clickThreshold = .5f;
    public HapticReceiver receiver;
    public string handName = "CS_R_CTRL_Left";

    private void Start()
    {
        if (receiver == null)
        {
            GameObject g = GameObject.Find(handName);
            receiver = g.GetComponentInChildren<HapticReceiver>();  
        }

    }
    void Update()
    {
        if (vibrato)
        {
            vibratoAmplitude = ((((Mathf.Sin(Time.time * vibratoData.x) + 1f) * .5f) * (vibratoData.z - vibratoData.y)) + vibratoData.y);
        }
        else
            vibratoAmplitude = amplitude;

        if(receiver!=null)
            receiver.Trigger(frequency, vibratoAmplitude, fadeSpeed);

    }


}

