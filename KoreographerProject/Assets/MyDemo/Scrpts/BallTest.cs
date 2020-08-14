using SonicBloom.Koreo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallTest : MonoBehaviour {
    //TODO:做一个球体的跳动效果
    private Rigidbody rigidbodyCom;//避免名称与rigidbody重复
    public string eventID;//事件id
    public float jumpSpeed;

	// Use this for initialization
	void Start () {
        rigidbodyCom = GetComponent<Rigidbody>();
        Koreographer.Instance.RegisterForEvents(eventID,BallJump);//引用SonicBloom.Koreo命名空间
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void BallJump(KoreographyEvent koreographyEvent)//注册进Koreographer的方法
    {
        Vector3 vel = rigidbodyCom.velocity;//刚体的速度向量
        vel.y = jumpSpeed;
        rigidbodyCom.velocity = vel;
    }
}
