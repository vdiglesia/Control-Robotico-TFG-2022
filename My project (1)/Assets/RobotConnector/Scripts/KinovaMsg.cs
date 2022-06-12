using ROSBridgeLib.geometry_msgs;
using SimpleJSON;

namespace RobotConnector.Scripts {
    namespace ITCL_msgs {
        public class KinovaMsg : ROSBridgeMsg {
            private TwistLinear _linear;
            private TwistAngular _angular;
            private FingersClosurePercentage _gripper;
			
            public KinovaMsg(JSONNode msg) {
                _linear = new TwistLinear(msg["linear"]);
                _angular = new TwistAngular(msg["angular"]);
                _gripper = new FingersClosurePercentage(msg["float"]);
            }
			
            public KinovaMsg(TwistLinear linear, TwistAngular angular, FingersClosurePercentage gripper) {
                _linear = linear;
                _angular = angular;
                _gripper = gripper;
            }
			
            public static string GetMessageType() {
                return "kinova_msgs/PoseVelocityWithFingers";
            }
			
            public Vector3Msg GetLinear() {
                return _linear;
            }

            public Vector3Msg GetAngular() {
                return _angular;
            }
			
            public override string ToString() {
                return "Twist [linear=" + _linear.ToString() + ",  angular=" + _angular.ToString() + "]";
            }
			
            public override string ToYAMLString() {
                return "{" + _linear.ToYAMLString() + ", " + _angular.ToYAMLString() + ", " + _gripper.ToYAMLString() +"}";
            }
        }
    }
}