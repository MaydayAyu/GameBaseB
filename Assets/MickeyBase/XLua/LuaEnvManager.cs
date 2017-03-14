using System.IO;
using System.Text;
using Tangzx.ABSystem;
using UnityEngine;
using XLua;

public static class KELua
{
    private static LuaEnv env = null;

    public static LuaEnv Instance
    {
        get
        {
            if (env == null)
            {
                env = new LuaEnv();
            }
            return env;
        }
    }

    static KELua()
    {
        //添加自定义的Loader
        Instance.AddLoader(AssetBundleLuaLoader);
    }

    /// <summary>
    /// 自定义的Loader，从更新的AB中去加载Lua文件
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    private static byte[] AssetBundleLuaLoader(ref string path)
    {
#if AB_MODE
        var bundleName = HashUtil.Get(("Assets.LuaScripts." + path + ".lua.txt").ToLower()) + ".ab";
        string assetPath = string.Format("{0}/{1}", AssetBundleManager.Instance.pathResolver.BundleCacheDir, bundleName);
        AssetBundle assetBundle = AssetBundle.LoadFromFile(assetPath);
        if (assetBundle == null)
        {
            return null;
        }
        TextAsset textAsset = assetBundle.LoadAsset<TextAsset>(assetBundle.GetAllAssetNames()[0]);
        assetBundle.Unload(false);
        return textAsset.bytes;
#else
        string realpath = Path.Combine(Application.dataPath, "LuaScripts");
        realpath = Path.Combine(realpath, path);
        realpath += ".lua.txt";
        string data = File.ReadAllText(realpath);
        return Encoding.UTF8.GetBytes(data);
#endif
    }
}