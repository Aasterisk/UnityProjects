using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class LightTest : MonoBehaviour {
    //TODO:通过四分音符与八分音符来开关效果光源
    public Light[] quarterNoteGroup;//四分音符对应的灯组
    public Light[] eighthNoteGroup;//八分音符对应的灯组

    private int lastQuarterNote = 0;//上一个四分音符
    private int lastEigthNote = 0;//上一个八分音符

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        int curQuarterNote =Mathf.FloorToInt(Koreographer.GetBeatTime());//先定义一个四分音符
        if (curQuarterNote!=lastQuarterNote)
        {
            //当前的四分音符与上一个四分音符不是同一个四分音符的时候
            //进行开灯关灯的操作。
            SwitchGroup(quarterNoteGroup, lastQuarterNote % 2 != 0);//开关灯的切换

            lastQuarterNote = curQuarterNote;
        }

        int curEighthNote= Mathf.FloorToInt(Koreographer.GetBeatTime(null,2));
        if (curEighthNote!=lastEigthNote)
        {
            SwitchGroup(eighthNoteGroup, lastEigthNote % 2 != 0);

            lastEigthNote = curEighthNote;
        }
    }

    private void SwitchGroup(Light[] lights,bool ifOpen)
    {
        for (int i = 0; i < lights.Length; i++)
        {
            lights[i].enabled = ifOpen;
        }
    }
}
