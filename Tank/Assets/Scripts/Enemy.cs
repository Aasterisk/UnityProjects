using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    //属性值
    public float moveSpeed = 3;
    private Vector3 bullectEulerAngles;
    private float v=-1;//开始时直接往下
    private float h;

    //引用
    private SpriteRenderer sr;
    public Sprite[] tankSprite;//上 右 下 左
    public GameObject bullectPrefab;
    public GameObject explosionPrefab;

    //计时器
    private float timeVal;//攻击间隔计时器
    private float timeValChangeDirection;//改变方向的计时器


    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        //攻击的时间间隔
        if (timeVal >= 3)
        {
            Attack();
        }
        else
        {
            timeVal += Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        Move();
    }

    //坦克的攻击方法
    private void Attack()
    {
        
       //子弹产生的角度：当前坦克的角度+子弹应该旋转的角度。
       Instantiate(bullectPrefab, transform.position, Quaternion.Euler(transform.eulerAngles + bullectEulerAngles));
       timeVal = 0;
        
    }


    //坦克的移动方法
    private void Move()
    {

        if (timeValChangeDirection>=4)
        {
            int num = Random.Range(0, 8);//通过随机数设置v和h的值来改变方向
            if (num>5)//使敌人朝下的概率变大
            {
                v = -1;
                h = 0;
            }
            else if (num==0)//往回走的概率设置的小一点
            {
                v = 1;
                h = 0;
            }
            else if (num>0&&num<=2)//向左
            {
                h = -1;
                v = 0;
            }
            else if (num > 2 && num <= 4)//向右
            {
                h = 1;
                v = 0;
            }

            timeValChangeDirection = 0;//转向后计时器归零
        }
        else
        {
            timeValChangeDirection += Time.fixedDeltaTime;//时间没有到四秒时
        }

     


        transform.Translate(Vector3.up * v * moveSpeed * Time.fixedDeltaTime, Space.World);

        if (v < 0)
        {
            sr.sprite = tankSprite[2];
            bullectEulerAngles = new Vector3(0, 0, -180);
        }

        else if (v > 0)
        {
            sr.sprite = tankSprite[0];
            bullectEulerAngles = new Vector3(0, 0, 0);
        }

        if (v != 0)
        {
            return;
        }

        
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime, Space.World);
        if (h < 0)
        {
            sr.sprite = tankSprite[3];
            bullectEulerAngles = new Vector3(0, 0, 90);
        }

        else if (h > 0)
        {
            sr.sprite = tankSprite[1];
            bullectEulerAngles = new Vector3(0, 0, -90);
        }
    }

    //坦克的死亡方法
    private void Die()
    {
        PlayerManager.Instance.playerScore++;
        //产生爆炸特效
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        //死亡
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Enemy")//碰撞时进行转向
        {
            timeValChangeDirection = 4;
        }
    }

}
