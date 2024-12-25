// using System.Collections;
// using System.Collections.Generic;
// using System.Net;
// using System.Net.Sockets;
// using System.Text;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// public class ClientTest1 : MonoBehaviour
// {
//     [SerializeField] private Button button;
//     [SerializeField] private TMP_InputField inputField;
//     private static Socket clientSocket;
//     private static string ip = "127.0.0.1";
//     private static int port = 4000;
//     // Start is called before the first frame update
//     void Start()
//     {
//          //1.建立服务器的Socket对象，同时绑定服务器端ip和端口
//             clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//             IPAddress ipAddress = IPAddress.Parse(ip);
//             EndPoint endPoint = new IPEndPoint(ipAddress, port);
//             clientSocket.Connect(endPoint);//对应服务端的一个Listen
//             Debug.Log("连接成功");

//         //  2.向服务端发送数据
//         string replyMessage = "你好 Server!";
//         byte[] returnData = Encoding.UTF8.GetBytes(replyMessage);
//         clientSocket.Send(returnData);
//         Debug.Log("向服务端发送数据："+replyMessage);
//         button.onClick.AddListener(SendMessage);

//         // 3.从服务端接受数据
//         byte[] data = new byte[1024];
//         int length = clientSocket.Receive(data);
//         string message = Encoding.UTF8.GetString(data,0, length);
//         Debug.Log("服务器端接收到客户端的消息："+message);
//     }

//     private void SendMessage()
//     {
//         string message = inputField.text;
//         byte[] data = Encoding.UTF8.GetBytes(message);
//         clientSocket.Send(data);
//         Debug.Log("客户端发送给服务器的消息：" + message);
//         inputField.text = "";
//     }
// }
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClientTest1 : MonoBehaviour
{
    private string serverIp = "127.0.0.1";
    private int serverPort = 4000;
    private Socket clientSocket;
    
    public TMP_InputField inputField;
    public Button button;

    private void Start()
    {
        // 创建与服务端通信的 Socket
        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        // 建立连接
        IPAddress ip = IPAddress.Parse(serverIp); // 解析ip地址
        EndPoint endPoint = new IPEndPoint(ip, serverPort);
        clientSocket.Connect(endPoint);
        Debug.Log("请求服务器连接");
        // 接收服务端的消息
        byte[] data = new byte[1024];
        int length = clientSocket.Receive(data);
        string message = Encoding.UTF8.GetString(data, 0, length); 
        Debug.Log("客户端收到来自服务器的消息：" + message);
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
}
