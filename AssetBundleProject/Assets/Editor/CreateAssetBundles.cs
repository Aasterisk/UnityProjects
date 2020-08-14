using UnityEditor;
using System.IO;

public class CreateAssetBundles  {
    //构建assetsbundle包
    [MenuItem("Assets/Build AssetBundles")]//使用了特性，将其放到菜单栏
    static void BuildAllAssetBundles()
    {
        string dir = "AssetBundles";
        if( Directory.Exists(dir)==false)
        {
            Directory.CreateDirectory(dir);
        }
        BuildPipeline.BuildAssetBundles(dir, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.StandaloneWindows64);
    }
	
}
