using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 弹动 : MonoBehaviour {
    public bool isFirsttimeToFlex;
	// Use this for initialization
	void Start () {
        isFirsttimeToFlex = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionStay(Collision collision)
    {
        if ((collision.gameObject.tag=="Cube"|| collision.gameObject.name =="Plane") && isFirsttimeToFlex && this.gameObject.name!="Cube (1)")
        {
            this.gameObject.GetComponent<Rigidbody>().AddForce(0,100,0);
            isFirsttimeToFlex = false;
        }
    }
}
