using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.objectnormal.mindstream
{
    public class HapticTransmitterGlobal : MonoBehaviour
    {
        public float frequency;
        public float amplitude;
        public float fadeSpeed;

        bool hovering;
        public float outFrequency;
        public float outAmplitude;
        public bool triggerOnEnter = false;
        public bool triggerOnHover = false;
        public bool triggerOnClicked = false;

        public bool vibrato;
        [Tooltip("X:frequency Y:Low Z:High")]
        public Vector4 vibratoData;
        float vibratoAmplitude;
        public float clickThreshold = .5f;

        public HapticReceiver[] receivers;
        public bool trigger;
        public float multiply;

        private void Start()
        {
            receivers = FindObjectsOfType<HapticReceiver>();
        }

        void Update()
        {
            if (trigger)
            {
                if (vibrato)
                {
                    vibratoAmplitude = (((Mathf.Sin(Time.time * vibratoData.x) + 1f) * .5f) * (vibratoData.z - vibratoData.y)) + vibratoData.y;
                }
                else
                    vibratoAmplitude = amplitude;
                //print(vibratoAmplitude);
                if (receivers.Length < 1)
                {
                    receivers = FindObjectsOfType<HapticReceiver>();

                }
                for (int i = 0; i < receivers.Length; i++)
                {
                    receivers[i].Trigger(frequency, vibratoAmplitude * multiply, fadeSpeed);
                }
            }
            //if (gaze!=null)
                //if(gaze.gameObject.GetComponent<HapticReceiver>()!=null)
                    //gaze.gameObject.GetComponent<HapticReceiver>()
        }



    }
}
