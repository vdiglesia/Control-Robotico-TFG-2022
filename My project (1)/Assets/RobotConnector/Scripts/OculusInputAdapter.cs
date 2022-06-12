using UnityEngine;

namespace RobotConnector.Scripts
{
    public class OculusInputAdapter : MonoBehaviour , IAdapter
    {
        public OculusInput oculusInput;

        public Vector3 GetLinearVelocity()
        {
            Vector3 data = new Vector3(oculusInput.lJoy.y, -oculusInput.lJoy.x,
                oculusInput.button2L ? 1f : oculusInput.button1L ? -1f:0f);
            return data;
        }

        public Vector3 GetAngularVelocity()
        {
            throw new System.NotImplementedException();
        }

        public float GetGripValue()
        {
            throw new System.NotImplementedException();
        }
    }
}
