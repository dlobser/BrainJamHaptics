using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class HapticReceiver : MonoBehaviour
    {
        public float frequency;
        public float amplitude;
        public float fadeSpeed;

        float hoverCounter;
        bool hovering;
        public float outFrequency;
        public float outAmplitude;

        [System.Serializable]
        public enum Hand { RIGHT, LEFT}
        public Hand hand = new Hand();

        List<UnityEngine.XR.InputDevice> leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevice rightHandDevice;
        // Find the Right Hand
        List<UnityEngine.XR.InputDevice> rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevice leftHandDevice;

        public void Trigger(float freq, float amp, float fSpeed)
        {
            hoverCounter = 1;
            frequency = freq;
            amplitude = amp;
            fadeSpeed = fSpeed;
        }

        private void Start()
        {
            SetupHands();
        }

        void SetupHands()
        {
            UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);

            if(leftHandDevices.Count>0)
                leftHandDevice = leftHandDevices[0];

            UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
            if (rightHandDevices.Count > 0)
                rightHandDevice = rightHandDevices[0];
        }

        //public void Hover()
        //{
        //    if (hoverCounter < 1)
        //    {
        //        hoverCounter += Time.deltaTime;
        //    }
        //    hovering = true;
        //}

        public void LateUpdate()
        {
            if (hoverCounter > 0)

            {
                if(leftHandDevices.Count<1 || rightHandDevices.Count < 1)
                {
                    SetupHands();
                }
                hoverCounter -= Time.deltaTime/fadeSpeed;

                // Find the Left Hand

                // Haptic Parameters
                uint channel = 0;
                //float amplitude = .5f;
                float duration = 1f;
                // Vibrate
                UnityEngine.XR.HapticCapabilities capabilities;
                //print("doing: " + hoverCounter);

                outFrequency = Mathf.Lerp(0, frequency, hoverCounter);
                outAmplitude = Mathf.Lerp(0, amplitude, hoverCounter);

                if(hand == Hand.LEFT)
                {
                    if (leftHandDevice.TryGetHapticCapabilities(out capabilities))
                    {
                        leftHandDevice.SendHapticImpulse(channel, Mathf.Round(outAmplitude*10) / 10, duration);
                    }

                }
                if (hand == Hand.RIGHT)
                {
                    if (rightHandDevice.TryGetHapticCapabilities(out capabilities))
                    {
                        rightHandDevice.SendHapticImpulse(channel, Mathf.Round(outAmplitude * 10) / 10, duration);
                    }
                }
            }


           
           
        }

    }
