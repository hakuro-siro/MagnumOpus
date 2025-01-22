using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using Google.Protobuf;

public class NetworkManager : MonoBehaviour
{
    static NetworkManager _instance;
    public static NetworkManager Instance { get { return _instance; } }
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    ServerSession _session = new ServerSession();

    public void Send(IMessage packet)
    {
        _session.Send(packet);
    }

    void Start()
    {
        Init();
    }

    public void Update()
    {
        List<PacketMessage> list = PacketQueue.Instance.PopAll();
        foreach (PacketMessage packet in list)
        {
            Action<PacketSession, IMessage> handler = PacketManager.Instance.GetPacketHandler(packet.Id);
            if (handler != null)
                handler.Invoke(_session, packet.Message);
        }
    }

    public void Init()
    {
        // DNS (Domain Name System)
        /*
        string host = Dns.GetHostName();
        IPHostEntry ipHost = Dns.GetHostEntry(host);
        IPAddress ipAddr = ipHost.AddressList[0];
        IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);
        */
        IPAddress ipA = IPAddress.Parse("????????");
        IPEndPoint endPoint = new IPEndPoint(ipA, 00000);

        Connector connector = new Connector();

        connector.Connect(endPoint,
            () => { return _session; },
            1);
    }
}
