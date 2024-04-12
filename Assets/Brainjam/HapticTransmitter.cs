using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//namespace com.objectnormal.mindstream
//{
    public class HapticTransmitter : Interactable
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
        public override void HandleTrigger()
        {
            base.HandleTrigger();
            if (vibrato)
            {
                vibratoAmplitude = (((Mathf.Sin(Time.time * vibratoData.x) + 1f) * .5f) * (vibratoData.z - vibratoData.y)) + vibratoData.y;
            }
            else
                vibratoAmplitude = amplitude;
            //print(vibratoAmplitude);
            if(gaze!=null)
                if(gaze.gameObject.GetComponent<HapticReceiver>()!=null)
                    gaze.gameObject.GetComponent<HapticReceiver>().Trigger(frequency,vibratoAmplitude,fadeSpeed);
        }

        public override void HandleHover()
        {
            base.HandleHover();
            if (triggerOnHover)
            {
                HandleTrigger();
            }
            //gaze.gameObject.GetComponent<HapticReceiver>().Trigger(frequency*hoverCounter, amplitude*hoverCounter);

        }

        //public override void HandleClicked()
        //{
        //    base.HandleClicked();
        //    if (triggerOnClicked)
        //    {
        //        HandleTrigger();
        //    }

        //    //gaze.gameObject.GetComponent<HapticReceiver>().Trigger(frequency*hoverCounter, amplitude*hoverCounter);

        //}

        public override void HandleEnter()
        {
            base.HandleEnter();
            HandleTrigger();
        }

        //public void LateUpdate()
        //{
        //    if (hovering && hoverCounter > 0)
        //    {
        //        hoverCounter -= Time.deltaTime;
        //    }

        //    outFrequency = Mathf.Lerp(0, frequency,  hoverCounter );
        //    outAmplitude = Mathf.Lerp(0, amplitude,  hoverCounter );
        //    hovering = false;
        //}

    }
//}
