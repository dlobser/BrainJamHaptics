using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.objectnormal.mindstream
{
    public class HapticsFromParticles : MonoBehaviour
    {
        public HapticTransmitterGlobal thisTransmitter;
        public HapticTransmitterGlobal turnOffTransmitter;
        public ParticleSystem particles;


        void Update()
        {
            if (particles.particleCount > 1 && !thisTransmitter.trigger)
            {
                thisTransmitter.trigger = true;
                turnOffTransmitter.trigger = false;
            }
            else if(particles.particleCount < 1 && thisTransmitter.trigger)
            {
                thisTransmitter.trigger = false;
                turnOffTransmitter.trigger = true;
            }
        }
    }
}