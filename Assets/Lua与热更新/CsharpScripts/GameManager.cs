using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using XLua;

public class GameManager : MonoBehaviour
{
    private string path = "http://localhost:8080";
//    private LuaEnv luaEnv = null;


    // Start is called before the first frame update
    void Start()
    {
        // luaEnv = new LuaEnv();
        // luaEnv.AddLoader(MyLoader);
        // LoadLua();
    }

    /// <summary>
    /// Lua存在服务器
    /// </summary>
    // public void LoadLua()
    // {
    //     StartCoroutine(WaitForLoadLua());
    // }
    //   IEnumerator WaitForLoadLua()
    // {
    //     UnityWebRequest request = UnityWebRequest.Get(path+"/LuaScripts/"+"Hotfix.lua"); 
    //     yield return request.SendWebRequest();
    //     string luaCode = request.downloadHandler.text;
    //     luaEnv.DoString(luaCode);
    // }

     IEnumerator WaitForLoadAssetBundle(string assetBundleName,string assetName)
    {
        UnityWebRequest request = UnityWebRequestAssetBundle.GetAssetBundle(path+"/AssetBundles/"+assetBundleName);
        // print(path+"/AssetBundles/"+assetBundleName);
        yield return request.SendWebRequest();
        AssetBundle assetBundle = DownloadHandlerAssetBundle.GetContent(request);
        GameObject asset = assetBundle.LoadAsset<GameObject>(assetName);
        Instantiate(asset);
    }
     public void LoadAsset(string assetBundleName,string assetName)
    {
    //    AssetBundle assetBundle = AssetBundle.LoadFromFile(Application.streamingAssetsPath+"/"+assetBundleName);
    //    GameObject cubeAsset = assetBundle.LoadAsset<GameObject>(assetName);
    //    Instantiate(cubeAsset);
         StartCoroutine(WaitForLoadAssetBundle(assetBundleName,assetName));
    }

    // private byte[] MyLoader(ref string fileName)
    // {
    //     string filePath = Application.dataPath + "/Lua与热更新/LuaScripts/" + fileName + ".lua";
    //     return File.ReadAllBytes(filePath);
    // }
    // private void OnDestroy()   
    // {
    //     luaEnv.Dispose();    
    // }
}
