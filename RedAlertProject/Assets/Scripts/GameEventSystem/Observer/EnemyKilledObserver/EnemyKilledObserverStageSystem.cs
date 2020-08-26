using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class EnemyKilledObserverStageSystem:IGameEventObserver
{
    //observer观察主题发生的变化，把结果返回给需要的系统
    private EnemyKilledSubject mSubject;
    private StageSystem mStageSystem;
    public EnemyKilledObserverStageSystem(StageSystem ss)
    {
        mStageSystem = ss;
    }

    public override void Update()
    {
        //将subject中死亡的个数传递给关卡系统
        mStageSystem.countOfEnemyKilled = mSubject.killedCount;
        //Debug.Log("Update:" + mSubject.killedCount);
    }

    public override void SetSubject(IGameEventSubject sub)
    {
        //做一个转型
        mSubject = sub as EnemyKilledSubject;
    }
}
