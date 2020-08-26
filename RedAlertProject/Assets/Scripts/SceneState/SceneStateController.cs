using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneStateController
{
    //TODO：用状态模式做场景切换
    private ISceneState mState;//私有变量的常用命名方式
    private AsyncOperation mAO;
    private bool mIsRunStart = false;

    public void SetState(ISceneState state,bool isLoadScene=true)
    {
        if (mState != null)
        {
            mState.StateEnd();//让上一个场景状态做一下清理工作
        }
        mState = state;
        if (isLoadScene)
        {
            mAO = SceneManager.LoadSceneAsync(mState.SceneName);
            mIsRunStart = false;
        } else
        {
            mState.StateStart();
            mIsRunStart = true;
        }
        
    }

    public void StateUpdate()
    {
        if (mAO != null && mAO.isDone == false) return;

        if (mIsRunStart==false&& mAO != null && mAO.isDone == true)
        {
            mState.StateStart();
            mIsRunStart = true;
        }

        if (mState != null)
        {
            mState.StateUpdate();
        }
    }
}
