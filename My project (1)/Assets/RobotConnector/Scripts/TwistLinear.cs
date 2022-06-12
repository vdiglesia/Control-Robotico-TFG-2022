using ROSBridgeLib.geometry_msgs;
using SimpleJSON;

namespace RobotConnector.Scripts {
    namespace geometry_msgs {
        public class TwistLinear : Vector3Msg {

            public TwistLinear(JSONNode msg) : base(msg)
            {
                _x = double.Parse(msg["x"]);
                _y = double.Parse(msg["y"]);
                _z = double.Parse(msg["z"]);
            }
			
            public TwistLinear(double x, double y, double z) : base(x, y, z)
            {
                _x = x;
                _y = y;
                _z = z;
            }
			
            public new static string GetMessageType() {
                return "geometry_msgs/twist_linear";
            }
			
            public new double GetX() {
                return _x;
            }
			
            public new double GetY() {
                return _y;
            }
			
            public new double GetZ() {
                return _z;
            }
			
            public override string ToString() {
                return "Vector3 [twist_linear_x=" + _x.ToString().Replace(",", ".") + ",  twist_linear_y="+ _y.ToString().Replace(",", ".") + ",  twist_linear_z=" + _z.ToString().Replace(",", ".") + "]";
            }
			
            public override string ToYAMLString() {
                return "\"twist_linear_x\" : " + _x.ToString().Replace(",", ".") + ", \"twist_linear_y\" : " + _y.ToString().Replace(",", ".") + ", \"twist_linear_z\" : " + _z.ToString().Replace(",", ".");
            }
        }
    }
}
