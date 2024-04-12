using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpMenuIntoPlace : MonoBehaviour {

    public GameObject target;
    public float speed;
    bool moving = false;
    bool canMove = false;
    public float moveDistance;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(target.transform.position.x, 1.5f, target.transform.position.z);

    }
	
	// Update is called once per frame
	void Update () {
        float dist = Vector3.Distance(new Vector3(target.transform.position.x, 1.5f, target.transform.position.z), new Vector3(this.transform.position.x, 1.5f, this.transform.position.z));
        if ( dist > moveDistance && !canMove) {
            moving = true;
            canMove = true;
        }
        if (dist < .2f) {
            moving = false;
            canMove = false;
        }
        if(moving)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.transform.position.x,1.5f, target.transform.position.z), (speed * Time.deltaTime)*dist);
        transform.LookAt(Camera.main.transform.position);
    }
}
