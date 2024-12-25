using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using XLua;

[Hotfix]
public class HotFixTest2 : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
   public Button button;
    private void Start() {
        button.onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
         gameManager.LoadAsset("prefabs","Cube");
    }
}