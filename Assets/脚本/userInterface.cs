using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class userInterface : MonoBehaviour {
    public GUIStyle labelStyle;
    public int score=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnGUI()
    {
        
        GUI.Label(new Rect(100, 100, 100, 100), score.ToString(),labelStyle);
    }
}
