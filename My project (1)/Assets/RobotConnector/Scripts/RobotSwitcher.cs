using UnityEngine;

//using UnityEngine.InputSystem.Switch;

namespace RobotConnector.Scripts
{
    public class RobotSwitcher : MonoBehaviour
    {
        public ROSInitializer rosObj;
        public string serviceName;
        public OculusInput oculusInput;

        private RobotnikDataManager sumit;

        private PinzaDataManager kinova;
    
        // Start is called before the first frame update

        private bool lastLJoyButtonValue;
        private bool lastRJoyButtonValue;
    
        void Start()
        {
            sumit = GetComponentInChildren<RobotnikDataManager>();
            kinova = GetComponentInChildren<PinzaDataManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if (lastLJoyButtonValue != oculusInput.buttonJoyL && oculusInput.buttonJoyL)
            {
                SwitchRobotControl();
            }

            lastLJoyButtonValue = oculusInput.buttonJoyL;
        
            if (lastRJoyButtonValue != oculusInput.buttonJoyR && oculusInput.buttonJoyR)
            {
                rosObj.CallService(serviceName,"");
            }
            lastRJoyButtonValue = oculusInput.buttonJoyR;
        }

        private void SwitchRobotControl()
        {
            sumit.enabled = !sumit.enabled;
            kinova.enabled = !kinova.enabled;
        }
    }
}
