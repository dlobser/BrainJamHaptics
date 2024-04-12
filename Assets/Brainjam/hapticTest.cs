using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ON;

public class hapticTest : MonoBehaviour
{
     public float frequency;
        public float amplitude;
        public float duration;
        public RaycastInteraction gaze;
            UnityEngine.XR.InputDevice rightHandDevice;
        // Find the Right Hand
        List<UnityEngine.XR.InputDevice> rightHandDevices = new List<UnityEngine.XR.InputDevice>();
        public bool send;
        GameObject prev;
    
    public AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.RightHand, rightHandDevices);
        if (rightHandDevices.Count > 0)
            rightHandDevice = rightHandDevices[0];

            print(rightHandDevice);
            StartCoroutine(HitTest());
    }

    // Update is called once per frame
    void LateUpdate()
    {
        UnityEngine.XR.HapticCapabilities capabilities;
          uint channel = 0;

        if(gaze.hitObject!=null){
            if(prev==null){
                send = true;
            }
        }

     
                //float amplitude = .5f;
        if (rightHandDevice.TryGetHapticCapabilities(out capabilities) && send)
        {
            rightHandDevice.SendHapticImpulse(channel, Mathf.Round(amplitude * 10) / 10, duration);
            print("sending");
            audio.pitch = Random.Range(.5f,1.5f);
            
        }

        prev = gaze.hitObject;
        
        Vector3 dir = this.transform.position - audio.gameObject.transform.position;
        float d = Vector3.Dot(Vector3.Normalize(dir),Vector3.Normalize(Camera.main.transform.forward));
        d*=3;
        d+=3;
        d = Mathf.Clamp(1-d,0,1);
        audio.volume = (d);
        send = false;
        // print(d);
    }

    IEnumerator HitTest(){
         uint channel = 0;
        float dist = 1;
        if(!gaze.hitPosition.Equals(Vector3.zero)){
            dist = Vector3.Distance(this.transform.position, gaze.hitPosition);
            if(dist<5)
                rightHandDevice.SendHapticImpulse(channel, Mathf.Round(Mathf.Clamp((amplitude*(1/dist)),0,1) * 10) / 10, duration);
            print("dist: " + dist);
            print("round: " + Mathf.Round((amplitude*(1/dist)) * 10) / 10);
        }
        if(Vector3.Distance(this.transform.position, gaze.hitPosition)<.3f){
            Vector3 translateNoiseOffset = gaze.hitObject.GetComponent<TransformUniversal>().translateNoiseOffset;
            Vector3 rando = Random.insideUnitSphere * 100;
            translateNoiseOffset += rando;
            gaze.hitObject.GetComponent<TransformUniversal>().translateNoiseOffset = translateNoiseOffset;
        }

        print("checking");
        yield return new WaitForSeconds(dist*.25f);
        StartCoroutine(HitTest());
    }

}
