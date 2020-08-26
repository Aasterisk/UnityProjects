using System;
using System.Collections.Generic;
using System.Text;


public class BattleState:ISceneState
{
    //TODO：用外观模式做一个子系统的管理
    //TODO：用单例模式访问
    //子系统包括：兵营 关卡 角色管理 行动力 成就系统
    public BattleState(SceneStateController controller):base("03BattleScene",controller)
    {}
    //兵营  关卡 角色管理 行动力 成就系统。。。

    public override void StateStart()
    {
        GameFacade.Insance.Init();
    }
    public override void StateEnd()
    {
        GameFacade.Insance.Release();
    }
    public override void StateUpdate()
    {
        if (GameFacade.Insance.isGameOver)
        {
            mController.SetState(new MainMenuState(mController));
        }

        GameFacade.Insance.Update();
    }
}

