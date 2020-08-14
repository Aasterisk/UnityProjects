using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SonicBloom.Koreo;

public class TextTest : MonoBehaviour {
    //TODO:做一个文字切换的效果
    public string eventID;

    private Text text;

    private KoreographyEvent curTextEvent;

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        Koreographer.Instance.RegisterForEventsWithTime(eventID, UpdateText);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void UpdateText(KoreographyEvent koreographyEvent, int sampleTime, int sampleDelta, DeltaSlice deltaSlice)
    {
        //判断当前事件是否有文本负荷
        if (koreographyEvent.HasTextPayload())
        {
            //当前存贮事件是否为空或者当前存贮事件不等于我们检测到的事件并且后边的事件为我们新检测到的事件
            if (curTextEvent==null||(koreographyEvent!=curTextEvent&&koreographyEvent.StartSample>curTextEvent.StartSample))
            {
                //文本的更新
                text.text = koreographyEvent.GetTextValue();
                curTextEvent = koreographyEvent;
            }
            //当前的音乐节奏执行拍子大于我们存贮事件的最后一拍的时候
            if (curTextEvent.EndSample < sampleTime)
            {
                //清空
                text.text = string.Empty;
                curTextEvent = null;
            }
        }

       
    }
}
