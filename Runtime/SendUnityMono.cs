using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using UnityEngine;

public class SendUDPTextMono : MonoBehaviour
{

    public string m_ipTarget = "127.0.0.1";
    public int m_portTarget = 2504;

    public string m_message;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {
    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        SendText("left");
    //    }

    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        SendText("right");
    //    }

    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        SendText("forward");
    //    }

    //    if (Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        SendText("backward");
    //    }

    //    if (Input.GetKeyDown(KeyCode.W))
    //    {
    //        SendText("up");
    //    }

    //    if (Input.GetKeyDown(KeyCode.S))
    //    {
    //        SendText("down");
    //    }

    //    if (Input.anyKeyDown)
    //    {
    //        print(Input.);
    //        SendText(KeyCode.S.ToString());
    //    }

    }

    [ContextMenu("Send Custom Message")]
    public void Sendmessage()
    {

        SendText(m_message);

    }

    [ContextMenu("Send Random 0 100")]
    public void SendRandom100()
    {

        SendText("" + (UnityEngine.Random.Range(0, 100)));

    }

    [ContextMenu("Send Random GUID")]
    public void SendRandomGUID()
    {
        SendText(System.Guid.NewGuid().ToString());

    }

    public void SendText(string text)
    {

        SendUdpMessage(text, m_ipTarget, m_portTarget);
    }

    static void SendUdpMessage(string message, string ipAddress, int port)
    {
        using (UdpClient udpClient = new UdpClient())
        {
            try
            {
                // Convert the message to bytes
                byte[] sendBytes = Encoding.UTF8.GetBytes(message);

                // Create an endpoint with the specified IP address and port
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);

                // Send the message
                udpClient.Send(sendBytes, sendBytes.Length, endPoint);

                Debug.Log("Sent message: " + message);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }
    }
}
