using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class HelloWorld02 : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
      //TextAsset ta=  Resources.Load<TextAsset>("helloworld.lua");
	  LuaEnv luaenv=new LuaEnv();
      //luaenv.DoString(ta.text);
      luaenv.DoString("require'helloworld'");
	  luaenv.Dispose();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
