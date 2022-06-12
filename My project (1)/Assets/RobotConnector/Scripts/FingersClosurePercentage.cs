using SimpleJSON;

/* 
 * @brief ROSBridgeLib
 * @author Alejandro Langarica. FUCK YOU!!
 */

namespace RobotConnector.Scripts {
    namespace geometry_msgs {
        public class FingersClosurePercentage : ROSBridgeMsg {
            private double _value;
            
			
            public FingersClosurePercentage(JSONNode msg) {
                _value = double.Parse(msg["value"]);
            }
			
            public FingersClosurePercentage(float x) {
                _value = x;
            }
			
            public static string GetMessageType() {
                return "geometry_msgs/fingers_closure_percentage";
            }
			
            public double GetValue() {
                return _value;
            }

            public override string ToString() {
                return "double [x=" + _value.ToString().Replace(",", ".") + "]";
            }
			
            public override string ToYAMLString() {
                return "\"fingers_closure_percentage\" : " + _value.ToString().Replace(",", ".");
            }
        }
    }
}