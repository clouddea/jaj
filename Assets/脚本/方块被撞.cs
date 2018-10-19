using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 方块被撞 : MonoBehaviour
{
    public GameObject myCamera;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionStay(Collision collision)
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name =="人" && gameObject!= myCamera.GetComponent<事件>().curStandCube && this.name!="Cube")
        {
            myCamera.GetComponent<事件>().CreateNewCube();//生成新的方块
            Vector2 this2DPosition = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.z);
            Vector2 collision2DPosition = new Vector2(collision.gameObject.transform.position.x, collision.gameObject.transform.position.z);
            float mu;
            if ((mu=Vector2.Distance(this2DPosition, collision2DPosition)) < 0.125f)//判断是否处于中心
            {
                GameObject scoreText = Transform.Instantiate(myCamera.GetComponent<事件>().scoreText, collision.gameObject.transform.position + new Vector3(0, 0.5f, 0), myCamera.GetComponent<事件>().scoreText.transform.rotation);//生成动态加分
                myCamera.GetComponent<事件>().constantCenter++;
                int constantCenter = myCamera.GetComponent<事件>().constantCenter;
                scoreText.GetComponent<ScoreTextScript>().score = 2*constantCenter ;
                for(int i=0;i< constantCenter; i++) { 
                    myCamera.GetComponent<userInterface>().score++;
                    myCamera.GetComponent<userInterface>().score++;
                }
                StartCoroutine(Wait(constantCenter));//生成helo

            }
            else
            {
                myCamera.GetComponent<事件>().constantCenter=0;
                myCamera.GetComponent<userInterface>().score++;
            }
        }
        // print("这：" + this.name + "/撞：" + collision.gameObject + "/现：" + myCamera.GetComponent<事件>().curStandCube.name); 
        if (collision.gameObject.name == "人")
        {
            myCamera.GetComponent<事件>().isJumping = false;
            myCamera.GetComponent<事件>().curStandCube = gameObject;
            myCamera.GetComponent<事件>().angle360 = 360f;//重置旋转
            myCamera.GetComponent<事件>().dampTime = 0.1f;//重置旋转
        }
    }
    IEnumerator Wait(int center)
    {
        for (int i = 0; i < center; i++)
        {
            Instantiate(myCamera.GetComponent<事件>().halo,myCamera.GetComponent<事件>().peopleCenter.transform.position, myCamera.GetComponent<事件>().halo.transform.rotation);
            yield return new WaitForSeconds(0.25f);
        }
        
    }
}
