using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 跟随 : MonoBehaviour {
    private Vector3 mu;
    public GameObject peopleCenter;
	// Use this for initialization
	void Start () {
        mu.x = transform.position.x - peopleCenter.transform.position.x;
        mu.z = transform.position.z - peopleCenter.transform.position.z;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = new Vector3(peopleCenter.transform.position.x + mu.x, transform.position.y, peopleCenter.transform.position.z+mu.z);
	}
}
