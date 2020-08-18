using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using XLua;

public class CreateLoader : MonoBehaviour {

	// Use this for initialization
	void Start () {
		LuaEnv env=new LuaEnv();
		env.AddLoader(MyLoader);//做一个查找，然后加载lua文件
        env.DoString("require 'test'");//在这里执行名称为test的lua文件
		env.Dispose();
	}
	
	private byte[] MyLoader(ref string filepath)//通过自定义的loader加载lua文件
    {
		//print(filepath);
        //string s = "print(123)";
		//print(Application.streamingAssetsPath);
       // return System.Text.Encoding.UTF8.GetBytes(s);
       string absPath = Application.streamingAssetsPath + "/" + filepath + ".lua.txt";
       return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(absPath));
    }
	// Update is called once per frame
	void Update () {
		
	}
}
