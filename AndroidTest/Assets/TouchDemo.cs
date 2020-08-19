using UnityEngine;
using UnityEngine.UI;

public class TouchDemo : MonoBehaviour 
{
    public GameObject effectPrefab;
    public Text infoText;
    GameObject markGo;
    string info;
    Vector2 touchOrigin;

    void Start()
    {
        Input.backButtonLeavesApp = true;
    }

    void Update () 
	{
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            info += "Escape\n";
        }
        //所有Touch类在PC端均不生效
        //每当一个手指触摸屏幕时，Unity都会为其生成一个Touch对象
        //Input.touchCount可以获取当前Touch对象的个数
        if (Input.touchCount > 0)
        {
            info = string.Empty;
            //以下三行在移动端也生效，带来方便的同时也会带来隐患
            info += "GetMouseButton(0) : " + Input.GetMouseButton(0) + "\n";
            info += "GetAxis(\"Mouse X\") : " + Input.GetAxis("Mouse X") + "\n";
            info += "GetAxis(\"Mouse Y\") : " + Input.GetAxis("Mouse Y") + "\n";
            info += "touchCount : " + Input.touchCount + "\n";
            //Unity会将当前存在的所有Touch对象放在Input.touches这个数组中
            //另一种方式获取指定Index的Touch对象：Input.GetTouch(index);
            Touch myTouch = Input.touches[0];
            //fingerId是用来识别当前手指的唯一标示
            info += "fingerId : " + myTouch.fingerId + "\n";
            //deltaPosition当前位置与上次位置之间的差
            info += "deltaPosition : " + myTouch.deltaPosition + "\n";
            //deltaTime本次记录Touch对象状态与上次记录Touch状态之间的时间差
            info += "deltaTime : " + myTouch.deltaTime + "\n";
            //Touch对象的生命周期的结束并不是手指离开屏幕后立刻销毁
            //如果一根手指在同一位置快速点击，则视作同一Touch对象
            //tapCount为Touch对象所对应的手指点击屏幕的次数
            info += "tapCount : " + myTouch.tapCount + "\n";
            //phase表示当前手指所对应的Touch对象的阶段（状态）
            info += "phase : " + myTouch.phase + "\n";
            //rawPosition为当前Touch对象所对应的手指的初始（刚按下时）屏幕坐标
            info += "rawPosition : " + myTouch.rawPosition + "\n";
            //position为当前Touch对象所对应的手指的屏幕坐标
            info += "position : " + myTouch.position + "\n";
            switch (myTouch.phase)
            {
                //当一个手指刚按下时，其对应的Touch对象的Phase是Began
                case TouchPhase.Began:
                    touchOrigin = myTouch.position;
                    markGo = Instantiate(effectPrefab, Camera.main.ScreenToWorldPoint(myTouch.position) + new Vector3(0, 0, 10), Quaternion.identity);
                    break;
                //当一个手指在屏幕上移动时，其对应的Touch对象的Phase是Moved
                case TouchPhase.Moved:
                //当一个手指在屏幕上按住不动时，其对应的Touch对象的Phase是Stationary
                case TouchPhase.Stationary:
                    markGo.transform.position = Camera.main.ScreenToWorldPoint(myTouch.position) + new Vector3(0, 0, 10);
                    break;
                //当一个手指离开屏幕时，其对应的Touch对象的Phase是Ended
                case TouchPhase.Ended:
                //当因为某些原因（系统原因）取消对某个手指的追踪时，其对应的Touch对象的Phase是Canceled
                case TouchPhase.Canceled:
                    if (touchOrigin.x >= 0 && touchOrigin.y >= 0)
                    {
                        Vector2 touchEnd = myTouch.position;
                        float x = touchEnd.x - touchOrigin.x;
                        float y = touchEnd.y - touchOrigin.y;
                        if (Mathf.Abs(x) > Mathf.Abs(y))
                        {
                            if (x > 0.25f)
                            {
                                info += "dir : Right\n";
                            }
                            else if (x < -0.25f)
                            {
                                info += "dir : Left\n";
                            }
                            else
                            {
                                info += "dir : Unknow\n";
                            }
                        }
                        else
                        {
                            if (y > 0.25f)
                            {
                                info += "dir : Up\n";
                            }
                            else if (y < -0.25f)
                            {
                                info += "dir : Down\n";
                            }
                            else
                            {
                                info += "dir : Unknow\n";
                            }
                        }
                    }
                    Destroy(markGo);
                    break;
                default:
                    break;
            }
        }
        infoText.text = info;
	}
}
