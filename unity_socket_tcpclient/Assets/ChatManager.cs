using System;
using UnityEngine;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class ChatManager : MonoBehaviour
{

    public string ipaddress = "192.168.0.101";
    public int port = 7788;
    public UIInput textInput;
    public UILabel chatLabel;

    private Socket clientSocket;

    private Thread t;
    private byte []data =new byte[1024];

    private string message = "";
	// Use this for initialization
	void Start ()
    {
        ConnectedToServer();

    }
	
	// Update is called once per frame
	void Update () {
        if (message != null && message != "")
        {
            chatLabel.text += "\n" + message;
            message = "";
        }
	
	}

     void ConnectedToServer()
    {
       clientSocket=new Socket(AddressFamily.InterNetwork ,SocketType.Stream,ProtocolType.Tcp);
	   //跟服务器建立连接
       clientSocket.Connect(new IPEndPoint(IPAddress.Parse(ipaddress ),port ));
        //创建一个线程来接受消息
        t = new Thread(ReceiveMessage);
        t.Start();
    }

     void ReceiveMessage()
     {
         while (true)
         {
             if (clientSocket.Connected == false)
             {
                 break;

             }
             int length = clientSocket.Receive(data); 
             message = Encoding.UTF8.GetString(data, 0, length);
             //chatLabel.text += "\n" + message;
         }
       
     }
     void SendMessage(string message)
     {
         byte[] data = Encoding.UTF8.GetBytes(message);
         clientSocket.Send(data);
     }

     public void OnSendButtonClick()
     {
         string value = textInput.value;
         SendMessage(value);
         textInput.value = "";
     }

     void OnDestroy()
     {
         clientSocket.Shutdown(SocketShutdown.Both);
         clientSocket.Close();
     }




}
