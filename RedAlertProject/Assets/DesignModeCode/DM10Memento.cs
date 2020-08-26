﻿using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class DM10Memento:MonoBehaviour
{
    void Start()
    {
        //Originator originator = new Originator();

        //originator.SetState("State1");
        //originator.ShowState();

        //Memento memento = originator.CreateMemento();//创建快照

        //originator.SetState("State2");
        //originator.ShowState();

        //originator.SetMemento(memento);
        //originator.ShowState();

        CareTaker careTaker = new CareTaker();

        Originator originator = new Originator();
        originator.SetState("state1");
        originator.ShowState();
        careTaker.AddMemento("v1.0", originator.CreateMemento());


        originator.SetState("state2");
        originator.ShowState();
        careTaker.AddMemento("v2.0", originator.CreateMemento());

        originator.SetState("state3");
        originator.ShowState();
        careTaker.AddMemento("v3.0", originator.CreateMemento());

        originator.SetMemento(careTaker.GetMemento("v2.0"));
        originator.ShowState();

        originator.SetMemento(careTaker.GetMemento("v1.0"));
        originator.ShowState();
    }
}

class Originator
{
    private string mState;
    public void SetState(string state)
    {
        mState = state;
    }
    public void ShowState()
    {
        Debug.Log("Originator state ：" + mState);
    }
    public Memento CreateMemento()
    {
        Memento memento = new Memento();
        memento.SetState(mState);
        return memento;
    }
    public void SetMemento(Memento memento)
    {
        SetState(memento.GetState());
    }
}

class Memento
{
    private string mState;
    public void SetState(string state)
    {
        mState = state;
    }
    public string GetState()
    {
        return mState;
    }
}

class CareTaker
{
    Dictionary<string, Memento> mMementoDict = new Dictionary<string, Memento>();
    public void AddMemento(string version, Memento memento)
    {
        mMementoDict.Add(version, memento);
    }
    public Memento GetMemento(string version)
    {
        if (mMementoDict.ContainsKey(version) == false)
        {
            Debug.LogError("快照字典中不包含key：" + version); return null;
        }
        return mMementoDict[version];
    }
}