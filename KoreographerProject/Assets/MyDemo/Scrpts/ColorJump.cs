using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class ColorJump : MonoBehaviour {
    //TODO:实现颜色的变化，使球体颜色渐变，使立方体颜色骤变
    public string eventID;
    public Renderer[] objectsToColor;//一个渲染器数组

	// Use this for initialization
	void Start () {
        Koreographer.Instance.RegisterForEventsWithTime(eventID,AdjustColor);//一个单例：初始化与回调方法。
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void AdjustColor(KoreographyEvent koreographyEvent,int sampleTime,int sampleDelta,DeltaSlice deltaSlice)
    {
        if (koreographyEvent.HasColorPayload())
        {
            Color targetColor = koreographyEvent.GetColorValue();
            ApplyColorToOjects(targetColor);
        }
        else if (koreographyEvent.HasGradientPayload())
        {
            Color targetColor = koreographyEvent.GetColorOfGradientAtTime(sampleTime);
            ApplyColorToOjects(targetColor);
        }
    }

    private void ApplyColorToOjects(Color color)
    {
        for (int i = 0; i < objectsToColor.Length; i++)
        {
            objectsToColor[i].material.color = color;
        }
    }
}
