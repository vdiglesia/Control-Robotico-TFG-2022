using UnityEngine;

namespace RobotConnector.Scripts
{
    public interface IAdapter
    {
        public Vector3 GetLinearVelocity();
        public Vector3 GetAngularVelocity();
        public float GetGripValue();
    }
}
