using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class HelloWorld01 : MonoBehaviour
{
    private LuaEnv luaenv;
	// Use this for initialization
	void Start () { 
        luaenv =new LuaEnv();
        //luaenv.DoString("print('Helloworld! ')");
        luaenv.DoString("CS.UnityEngine.Debug.Log('HelloWorld!')");
        //luaenv.Dispose();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDestroy()
    {
        luaenv.Dispose();
    }
}
