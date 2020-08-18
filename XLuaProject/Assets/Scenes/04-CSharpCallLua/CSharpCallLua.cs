using System.Collections;
using System.Collections.Generic;
using UnityEngine;using XLua;
using System;

public class CSharpCallLua : MonoBehaviour {

	// Use this for initialization
	void Start () {
        LuaEnv luaEnv = new LuaEnv();

        luaEnv.DoString("require 'CSharpCallLua'");//  number  --  int float double 

        //double a = luaEnv.Global.Get<double>("a");//获取到lua里面的全局变量 a
        //print(a);
        //string str = luaEnv.Global.Get<string>("str");//获取到lua里面的全局变量 a
        //print(str);
        //bool isDie = luaEnv.Global.Get<bool>("isDie");//获取到lua里面的全局变量 a
        //print(isDie);

        //1,通过class(struct)
        //Person p = luaEnv.Global.Get<Person>("person");
        //print(p.name+"-"+ p.age+"-"+p.age2);
        //p.name = "Sikiedu.com";
        //luaEnv.DoString("print(person.name)");

        //2,通过interface
        //IPerson p = luaEnv.Global.Get<IPerson>("person");
        //print(p.name+"-"+p.age);
        //p.name = "Sikiedu.com";
        //luaEnv.DoString("print(person.name)");
        //p.eat(12,34);//  p.eat(p,12,34);

        //3,通过Dictionary、List
        //Dictionary<string, object> dict = luaEnv.Global.Get<Dictionary<string, object>>("person");
        //foreach(string key in dict.Keys)
        //{
        //    print(key + "-" + dict[key]);
        //}
        //List<int> list = luaEnv.Global.Get<List<int>>("person");
        //foreach (object o in list)
        //{
        //    print(o);
        //}

        //4,通过LuaTable
        //LuaTable tab= luaEnv.Global.Get<LuaTable>("person");
        //print(tab.Get<string>("name"));
        //print(tab.Get<int>("age"));
        //print(tab.Length);

        //访问Lua中的全局函数

        //Action act1 = luaEnv.Global.Get<Action>("add");
        //act1();
        //act1 = null;

        //1、映射到Delegate
        //Add add = luaEnv.Global.Get<Add>("add");
        //int resa=0; int resb=0;
        //int res = add(34, 78,out resa,out resb);
        //print(res);
        //print(resa);
        //print(resb);
        //add = null;

        //2、映射到LuaFunction
        LuaFunction func = luaEnv.Global.Get<LuaFunction>("add");
        object[] os= func.Call(1, 2);
        foreach(object o in os)
        {
            print(o);
        }

        luaEnv.Dispose();
	}
    [CSharpCallLua]
    delegate int Add(int a, int b,out int resa,out int resb); 
	class Person
    {
        public string name;
        public int age;
        public int age2;
    }

    [CSharpCallLua]
    interface IPerson
    {
        string name { get; set; }
        int age { get; set; }
        void eat(int a,int b);
    }
}
