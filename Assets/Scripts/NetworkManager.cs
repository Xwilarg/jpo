using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    private TcpListener server;
    private TcpClient client;

    private void Start()
    {
        client = null;
        const int port = 7777;
        server = new TcpListener(IPAddress.Any, port);
        server.Start();
        StartListening();
    }

    public void sendDatas(string data)
    {
        NetworkStream s = client.GetStream();
        StreamWriter sw = new StreamWriter(s);
        sw.WriteLine("JPO" + data);
        sw.Flush();
    }

    private void Update()
    {
        if (client == null)
            return;
        try
        {
            NetworkStream s = client.GetStream();
            StreamReader sr = new StreamReader(s, true);
            if (s.DataAvailable)
            {
                string datas = sr.ReadLine();
                if (datas.Length > 3 && datas.Substring(0, 3) == "JPO")
                {
                    datas = datas.Substring(3, datas.Length - 3);
                    if (datas == "PING")
                        sendDatas("PING");
                    else if (datas == "PINGREG")
                        sendDatas("PINGREG");
                    else if (datas == "CHECK")
                        sendDatas("OK");
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }

    private void StartListening()
    {
        server.BeginAcceptTcpClient(AcceptTcpClient, server);
    }

    private void AcceptTcpClient(IAsyncResult iar)
    {
        TcpListener listener = (TcpListener)iar.AsyncState;
        client = listener.EndAcceptTcpClient(iar);
        StartListening();
    }
}
