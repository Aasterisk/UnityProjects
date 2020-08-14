using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class CubeTest : MonoBehaviour {

    public string eventID;
    //TODO:做一个立方体变大变小的效果
    public float minScale = 0.5f;//立方体的最小值
    public float maxScale = 1.5f;//立方体放大的最大值

	// Use this for initialization
	void Start () {
        Koreographer.Instance.RegisterForEventsWithTime(eventID, ChangeCube);//立方体的注册，用RegisterForEventsWithTime因为随时间渐变曲线
        //ChangeCube是一个回调方法
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void ChangeCube(KoreographyEvent koreographyEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        if (koreographyEvent.HasCurvePayload())
        {
            float curveValue = koreographyEvent.GetValueOfCurveAtTime(sampleTime);//由样本时间获得曲线值
            transform.localScale = Vector3.one * Mathf.Lerp(minScale, maxScale, curveValue);
        }
    }
}
