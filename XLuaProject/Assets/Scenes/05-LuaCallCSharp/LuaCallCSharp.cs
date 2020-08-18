using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

enum EnemyType
{
    Normal,
    Hard,
    NB
}
public class LuaCallCSharp : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LuaEnv luaEnv = new LuaEnv();
   
        luaEnv.DoString("require 'LuaCallCSharp'");

        luaEnv.Dispose();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
