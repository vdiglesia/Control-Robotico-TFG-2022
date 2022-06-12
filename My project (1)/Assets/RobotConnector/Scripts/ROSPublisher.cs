using ROSBridgeLib;
using ROSBridgeLib.geometry_msgs;
using SimpleJSON;

namespace RobotConnector.Scripts
{
    public class ROSPublisher : ROSBridgePublisher
    {
        public static RosConfigScriptable configData;
        // The following three functions are important
        public new static string GetMessageTopic() {
            //topic name is up to the user
            //return "/twist_info";
            return configData.msgTopic;
        }

        public new static string GetMessageType() {
            //return "geometry_msgs/Twist";
            return configData.msgType;
        }

        public static string ToYAMLString(TwistMsg msg) {
            return msg.ToYAMLString();
        }

        public static ROSBridgeMsg ParseMessage(JSONNode msg) {
            return new TwistMsg(msg);
        }    
    }
}