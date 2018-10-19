using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class halo : MonoBehaviour {
    private float time;
    private float deltaScale;
    private float deltaOpacity;
    private float curScale;
    private float curOpacity;
    // Use this for initialization
    void Start () {
        time = 50;
        deltaScale = 0.02f / time;
        deltaOpacity = 1 / time;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (time>0)
        {
            curScale = this.gameObject.transform.localScale.x;
            curOpacity = this.gameObject.GetComponent<SpriteRenderer>().color.a;
            this.gameObject.transform.localScale = new Vector3(curScale+ deltaScale, curScale+ deltaScale, 0);//扩大
            if(curOpacity>0)this.gameObject.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, curOpacity - deltaOpacity);//fade
            time--;
        }
        else
        {
            Destroy(this.gameObject);
        }
	}
}
