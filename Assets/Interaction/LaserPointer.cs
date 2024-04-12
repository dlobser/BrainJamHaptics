using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour {

    public RaycastHit hit;
    public GameObject particles;
    public GameObject endPoint;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (Physics.Raycast(transform.position, transform.forward, out hit)) {
            transform.localScale = new Vector3(1,1, Vector3.Distance(this.transform.position,hit.point));
            
        }
        else {
            transform.localScale = new Vector3(1,1,100);
        }
        particles.transform.position = endPoint.transform.position;
    }
}
