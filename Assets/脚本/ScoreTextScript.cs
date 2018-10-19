using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTextScript : MonoBehaviour {
    public int score=-1;
	// Use this for initialization
	void Start () {

        print("开始：" + Time.time);
        StartCoroutine(Wait());
        print("结束：" + Time.time);
    }

    // Update is called once per frame
    private void FixedUpdate () {
        GetComponent<TextMesh>().text ="+"+ score.ToString();
        this.transform.Translate(0,1*Time.deltaTime,0);
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        if(this.name!="scoreText")Transform.Destroy(this.gameObject);
    }
}
