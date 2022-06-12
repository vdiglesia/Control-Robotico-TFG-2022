using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
//using ROSBridgeLib.ITCL_msgs;
using UnityEngine.UIElements;

public class KinovaFingersController : MonoBehaviour
{
    public ROSInitializer rosObj;
    //public KinovaPositionController positionController;
    public string topic= "/robot/j2s6s200_gripper_controller/gripper_command/goal";
    [Range(0f,1f)]
    public float position ;
    public float lastPosition;
    public float effort;
    public float lastEffort;
    public bool send;
    
    public string frameID = "robot_j2s6s200_link_base";
    private int seq;
    private int sec;
    private int nsec;
    private string id;
    private int offsetSeq;

    public string msgToSend;

    public GripperGoalMsg gripperGoal;
    void Update()
    {
        position = Mathf.Clamp01(position);
        gripperGoal = new GripperGoalMsg(position, effort, frameID, sec, nsec, seq, id);
        msgToSend = gripperGoal.ToYAMLString();
        
        if (!rosObj.connected) return;
        if (position!=lastPosition)
        {
            rosObj.Publish(topic,gripperGoal);
            Debug.Log("Enviado mensaje de pinza!!");
            send = false;
        }

        lastPosition = position;
        //lastEffort = effort;
    }
}
