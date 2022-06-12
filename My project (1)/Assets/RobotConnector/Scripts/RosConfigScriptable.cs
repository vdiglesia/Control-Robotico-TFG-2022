using UnityEngine;

namespace RobotConnector.Scripts
{
    [CreateAssetMenu(fileName = "DataConfig", menuName = "ScriptableObjects/RosConfig", order = 1)]
    public class RosConfigScriptable : ScriptableObject
    {
        public string topic;
        public string msgType;
        public string msgTopic;
    }
}
