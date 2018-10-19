using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class 死亡并重新开始 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "人") {
            print("game over");
            //Application.LoadLevel(Application.loadedLevel);
            int curScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.UnloadSceneAsync(curScene);
            SceneManager.LoadScene(curScene);
        }
    }
}
