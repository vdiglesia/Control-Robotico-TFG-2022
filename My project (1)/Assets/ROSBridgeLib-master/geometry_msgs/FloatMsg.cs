using System.Collections;
using System.Text;
using SimpleJSON;
using ROSBridgeLib.geometry_msgs;

/* 
 * @brief ROSBridgeLib
 * @author Alejandro Langarica. FUCK YOU!!
 */

namespace ROSBridgeLib {
    namespace geometry_msgs {
        public class FloatMsg : ROSBridgeMsg {
            private double _x;
            
			
            public FloatMsg(JSONNode msg) {
                _x = double.Parse(msg["x"]);
            }
			
            public FloatMsg(float x) {
                _x = x;
            }
			
            public static string GetMessageType() {
                return "geometry_msgs/float";
            }
			
            public double GetX() {
                return _x;
            }

            public override string ToString() {
                return "Vector3 [x=" + _x.ToString().Replace(",", ".") + "]";
            }
			
            public override string ToYAMLString() {
                return "{\"x\" : " + _x.ToString().Replace(",", ".") + "}";
            }
        }
    }
}