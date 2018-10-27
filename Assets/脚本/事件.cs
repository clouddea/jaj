using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 事件 : MonoBehaviour {
    private float mouseHoldTime = 0f;
    private Rigidbody peopleRigidBody;
    public GameObject people;
    public GameObject scoreText;
    public GameObject peopleCenter;
    public Transform newCube;
    public bool isJumping;
    public GameObject curStandCube;
    public int constantCenter;
    private int jumpDir;
    private Quaternion originRotation;
    private Vector3 muBetweenPeopleAndCenter;
    public float angle360;
    public float dampTime;
    public GameObject halo;
    // Use this for initialization
    void Start () {
        peopleRigidBody = people.GetComponent<Rigidbody>();
        jumpDir = 1;//一开始是向+z方向跳的
        isJumping = false;
        originRotation = people.transform.rotation;//记录原始旋转信息
        angle360 = 360f;
        dampTime = 0.1f;//跳跃缓冲时间
        people.GetComponent<ParticleSystem>().Stop();//默认关闭粒子系统
        muBetweenPeopleAndCenter = peopleCenter.transform.position - people.transform.position;//记录人物中心到脚的向量差
    }
	
	// Update is called once per frame
	
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            mouseHoldTime += 0.02f;
            people.transform.localScale = new Vector3(0.3f,0.3f*(1.0f-(mouseHoldTime/4<=0.8f?mouseHoldTime/4:0.8f)),0.3f);//人物压缩
            curStandCube.transform.localScale = new Vector3(0.5f, 0.2f * (1.0f - (mouseHoldTime / 4 <= 0.5f ? mouseHoldTime / 4 : 0.5f)), 0.5f);//方块压缩
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            people.GetComponent<ParticleSystem>().Play();//启动粒子系统
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            print("你按住了鼠标左键:" + mouseHoldTime + "秒");
            if (mouseHoldTime>0f && !isJumping)//当鼠标按下并且不处于跳跃状态时
            {
                peopleRigidBody.AddForce(new Vector3(-(jumpDir == 2 ? mouseHoldTime * 80 : 0), 200, (jumpDir == 1 ? mouseHoldTime * 80 : 0)));//人物跳跃
                isJumping = true;
            }
            mouseHoldTime = 0f;
            people.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);//人物恢复初始比例
            curStandCube.transform.localScale = new Vector3(0.5f, 0.2f, 0.5f);//方块恢复初始比例
            people.GetComponent<ParticleSystem>().Stop();//停用粒子系统
            people.GetComponent<ParticleSystem>().Clear();//清除粒子系统中残余粒子
            
        }
        if (isJumping)
        {
            if (angle360 > 0f && dampTime<0)
            {
                people.transform.RotateAround(peopleCenter.transform.position, (jumpDir == 1 ? new Vector3(1, 0, 0):new Vector3(0,0,1)), 720f * Time.deltaTime);
                angle360 -= 720f * Time.deltaTime;
            }
            else
            {
                Vector3 recoverPos = peopleCenter.transform.position;
                people.transform.rotation = originRotation;//重置旋转
                people.transform.position = recoverPos - muBetweenPeopleAndCenter;//重置位置
            }
            dampTime -= Time.deltaTime;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        print("我被撞了："+collision.gameObject.name);
    }
    public void CreateNewCube()
    {
        Vector3 newPos;//用于计算新产生的cube位置
        int randomDir = Random.Range(1, 3);//产生1,2随机数
        float randomLen = Random.Range(0f, 1.4f);
        jumpDir = randomDir;//记录这个方向，方便跳跃使用
        if (randomDir == 2)//如果方向为-x向
        {
            newPos = new Vector3(newCube.transform.position.x - 0.5f - randomLen, newCube.transform.position.y + 1, newCube.transform.position.z);
        }
        else//如果方向为+z向
        {
            newPos = new Vector3(newCube.transform.position.x, newCube.transform.position.y + 1, newCube.transform.position.z + 0.5f + randomLen);
        }
        newCube = Transform.Instantiate(newCube, newPos, newCube.transform.rotation);//生成新的方块
    }
}
