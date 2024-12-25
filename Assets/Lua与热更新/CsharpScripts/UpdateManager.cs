using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using XLua;

public class UpdateManager : MonoBehaviour
{
    private LuaEnv luaEnv = null;
    
    private const string updateCheckURL = "http://localhost:8080/checkUpdate"; // 替换成实际的服务器地址

    private void Awake()
    {
        luaEnv = new LuaEnv();
    }
    
    void Start()
    {
        StartCoroutine(CheckForUpdate());
    }

    IEnumerator CheckForUpdate()
    {
        UnityWebRequest www = UnityWebRequest.Get(updateCheckURL);

        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("更新检查失败: " + www.error);
        }
        else
        {
            string serverVersion = www.downloadHandler.text; // 1.1
            string currentVersion = Application.version;

            if (IsUpdateRequired(currentVersion, serverVersion))
            {
                Debug.Log("需要更新");
                // 这里可以触发更新操作，比如下载最新版本的资源包和Lua脚本
                StartCoroutine(LoadLuaAsync("Hotfix.lua", () =>
                {
                    SceneManager.LoadScene("GameScene");
                }));
            }
            else
            {
                Debug.Log("应用程序已经是最新版本");
                SceneManager.LoadScene("GameScene");
            }
        }
    }

    bool IsUpdateRequired(string currentVersion, string serverVersion)
    {
        // 实现你的版本比较逻辑，例如使用 SemVer 规范比较版本号
        // 这里仅提供一个简单的比较，你可能需要根据项目需求进行更复杂的比较
        Version current = new Version(currentVersion);
        Version server = new Version(serverVersion);
        Debug.Log(currentVersion + ", " + serverVersion);
        return current < server;
    }
    
    IEnumerator LoadLuaAsync(string luaName, Action callback)
    {
        string luaPath = "http://127.0.0.1:3000/LuaScripts/" + luaName;
        UnityWebRequest request = UnityWebRequest.Get(luaPath);
        yield return request.SendWebRequest();
        string luaScript = request.downloadHandler.text;
        luaEnv.DoString(luaScript);
        callback?.Invoke();
    }
    
    private void OnDestroy()
    {
        luaEnv.Dispose(); // 释放Lua运行环境
    }
}