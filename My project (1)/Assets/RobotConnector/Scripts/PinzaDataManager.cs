using RobotConnector.Scripts.ITCL_msgs;
using ROSBridgeLib.geometry_msgs;
using UnityEngine;

namespace RobotConnector.Scripts
{
    public class PinzaDataManager : MonoBehaviour
    {
        public OculusInput oculusInput;
        public ROSInitializer rosObj;
        public string topic;
    
    
        TwistLinear linearVel;
        TwistAngular angularVel;
        FingersClosurePercentage gripVal;
    
        KinovaMsg msg;

        public Vector3 linearVelocity;
        public Vector3 angularVelocity;
        public float factor = 100;
    
    
        // Update is called once per frame
        void Update()
        {
            //dependant on the message defintion:
            linearVel=new TwistLinear(
                (double)linearVelocity.x,
                (double)linearVelocity.y,
                (double)linearVelocity.z
                /*oculusInput.lJoy.y*factor,
            -oculusInput.lJoy.x*factor,
            oculusInput.button2L?1*factor:oculusInput.button1L?-1*factor:0*/
            );
            angularVel=new TwistAngular(
                (double)angularVelocity.x,
                (double)angularVelocity.y,
                (double)angularVelocity.z
                /*oculusInput.rJoy.y*factor,
            oculusInput.rJoy.x*factor,
            oculusInput.button2R?1*factor:(oculusInput.button1R?-1*factor:0)*/
            );
        
            gripVal = new FingersClosurePercentage(oculusInput.TriggerR*100f);
        
            msg=new KinovaMsg(linearVel,angularVel,gripVal);
            rosObj.Publish(topic,msg);
        }
    }
}
