using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 看不见摧毁 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnBecameInvisible()
    {
        Transform.Destroy(this.gameObject,0);
    }
}
