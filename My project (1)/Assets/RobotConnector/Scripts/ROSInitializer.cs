using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using ROSBridgeLib_master;

public class ROSInitializer  : MonoBehaviour
{
    public string serverIP;

    public int port;
    private ROSBridgeWebSocketConnection ros = null;
    public bool connected;
    
    void Awake() {
        // Where the rosbridge instance is running, could be localhost, or some external IP
        ros = new ROSBridgeWebSocketConnection ("ws://"+serverIP, port);

        try
        {
            ros.Connect();
            Invoke("SetConnected",2f);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    void SetConnected()
    {
        connected = true;
    }

    // Extremely important to disconnect from ROS. Otherwise packets continue to flow
    void OnApplicationQuit() {
        if(ros!=null) {
            ros.Disconnect ();
        }
    }
    // Update is called once per frame in Unity
    void Update () {
        ros.Render ();
    }

    public void Publish(string topic, ROSBridgeMsg msg)
    {
        ros.Publish(topic,msg);
    }

    public void Publish(string topic, string msg)
    {
        ros.Publish(topic,msg);
    }

    public void CallService(string serviceName, string args)
    {
        ros.CallService(serviceName, args);
    }
    
}