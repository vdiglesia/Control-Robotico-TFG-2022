using System.Numerics;
using RobotConnector.Scripts;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace MyScripts
{
    public class BotHandsLink : MonoBehaviour
    {
        public Transform questRight;
        public Vector3 vect;
        public Vector3 original;
        public Quaternion rotation;
        public float x, y, z;
        public KinovaPositionController kinova;
        public KinovaFingersController gripp;
        
        // Start is called before the first frame update
        void Start()
        { 
            original.x = questRight.position.x;
            original.y = questRight.position.y;
            original.z = questRight.position.z;
            
            kinova.enabled = true;
            gripp.enabled = false;
        }

        private void BotHandsLinking()
        { 
            x = questRight.position.x -  original.x;
            y = questRight.position.y - original.y;
            z = questRight.position.z - original.z;
            if (x<-0.5)
            {x = -0.5f;}
            else if (x>0.5)
            { x = 0.5f;}
            if (y < 0)
            { y = 0;}
            y = (y + 0.1f)*1.7f;
            if (z<0)
            {z = 0;}
            z = (z + 0.15f)*1.5f;
            kinova.targetPosition.x = x;
            kinova.targetPosition.y = y;
            kinova.targetPosition.z = z;
        }
        // Update is called once per frame
        void Update()
        {
            vect = questRight.transform.position;
            BotHandsLinking();
            
            
            if (OVRInput.GetDown(OVRInput.Button.One, OVRInput.Controller.LTouch))
            {
                SwitchControllers();
            }
        }

        private void SwitchControllers()
        {
            kinova.enabled = !kinova.enabled;
            gripp.enabled = !kinova.enabled;
        }
    }
}
