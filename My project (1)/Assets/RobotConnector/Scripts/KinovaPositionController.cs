using ROSBridgeLib.geometry_msgs;
using ROSBridgeLib;
using SGCore.Kinematics;
using UnityEngine;

namespace RobotConnector.Scripts
{
    public class KinovaPositionController : MonoBehaviour
    {
        public ROSInitializer rosObj;
        public string topic;
        public Vector3 targetPosition;
        public Transform target;
        public string frameID = "robot_j2s6s200_link_base";
        private int seq;
        private int sec;
        private int nsec;
        private string id;
        private int offsetSeq;

        public PoseStampedGoalMsg poseStampedGoalMsg;
        

    
        void Update()
        { 
            Vector3 position2 = new Vector3(targetPosition.z, -targetPosition.x, targetPosition.y);
            Quaternion rotation = new Quaternion(target.rotation.z, -target.rotation.x, target.rotation.y,
                -target.rotation.w);
            poseStampedGoalMsg = new PoseStampedGoalMsg(position2, rotation, frameID, sec, nsec, seq, id);
            rosObj.Publish(topic,poseStampedGoalMsg);
        }
    }
}
