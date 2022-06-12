using ROSBridgeLib.geometry_msgs;
using UnityEngine;

namespace RobotConnector.Scripts
{
    public class RobotnikDataManager : MonoBehaviour
    {
        private const float speedFactor = 0.5f;
        public OculusInput oculusInput;
        public ROSInitializer rosObj;
        public string topic;
        
        Vector3Msg linearVel;
        Vector3Msg angularVel;
        TwistMsg msg;

        public Vector3 linearVelocity;
        public Vector3 angularVelocity;

    
    
        // Update is called once per frame
        void Update()
        {
            //dependant on the message defintion:
            linearVel=new Vector3Msg(
                (double)linearVelocity.x,
                (double)linearVelocity.y,
                (double)linearVelocity.z
                /*oculusInput.lJoy.y*oculusInput.TriggerL*speedFactor,
            -oculusInput.lJoy.x*oculusInput.TriggerL*speedFactor,
            0*/
            );
            angularVel=new Vector3Msg(
            
                (double)angularVelocity.x,
                (double)angularVelocity.y,
                (double)angularVelocity.z
                /*0,
            0,
            -oculusInput.rJoy.x*oculusInput.TriggerL*speedFactor*/
            );
            msg=new TwistMsg(linearVel,angularVel);
            rosObj.Publish(topic,msg);
        }
    }
}