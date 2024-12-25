using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClientTest2 : MonoBehaviour
{
    private string serverIp = "127.0.0.1";
    private int serverPort = 4000;
    private Socket clientSocket;
    
    public TMP_InputField inputField;
    public Button button;

    private bool isConnected = false;
    
    private void Start()
    {
        // 创建与服务端通信的 Socket
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        // 建立连接
        IPAddress ip = IPAddress.Parse(serverIp); // 解析ip地址
        EndPoint endPoint = new IPEndPoint(ip, serverPort);
        clientSocket.Connect(endPoint);
        // Debug.Log("请求服务器连接");
        // isConnected = true;
        // Thread thread = new Thread(ReceiveMessage);
        // thread.IsBackground = true; // 设置后台线程，随主线程结束而结束
        // thread.Start();
        
        button.onClick.AddListener(SendMessage);
    }

    private void SendMessage()
    {
        string message = inputField.text;
        byte[] data = Encoding.UTF8.GetBytes(message);
        clientSocket.Send(data);
        Debug.Log("客户端发送给服务器的消息：" + message);
        inputField.text = "";
    }

//     void ReceiveMessage()
//     {
//         try
//         {
//             while (isConnected)
//             {
//                 if (!clientSocket.Connected)
//                 {
//                     isConnected = false;
//                     break;
//                 }

//                 byte[] data = new byte[1024];
//                 int length = clientSocket.Receive(data);
//                 string message = Encoding.UTF8.GetString(data, 0, length);
//                 Debug.Log("客户端收到来自服务器的消息：" + message);
//             }
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine(e.Message);
//             isConnected = false;
//         }finally
//         {
//             // 关闭套接字，释放资源
//             clientSocket.Shutdown(SocketShutdown.Both);
//             clientSocket.Close(); // 关闭套接字
//         }
//     }

//     private void OnDestroy()
//     {
//         isConnected = false;
//     }
}
