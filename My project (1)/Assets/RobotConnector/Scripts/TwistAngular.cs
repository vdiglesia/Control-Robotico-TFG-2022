using ROSBridgeLib.geometry_msgs;
using SimpleJSON;

namespace RobotConnector.Scripts {
    namespace geometry_msgs {
        public class TwistAngular : Vector3Msg {

            public TwistAngular(JSONNode msg) : base(msg)
            {
                _x = double.Parse(msg["x"]);
                _y = double.Parse(msg["y"]);
                _z = double.Parse(msg["z"]);
            }
			
            public TwistAngular(double x, double y, double z) : base(x, y, z)
            {
                _x = x;
                _y = y;
                _z = z;
            }
			
            public new static string GetMessageType() {
                return "geometry_msgs/twist_angular";
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
                return "Vector3 [twist_angular_x=" + _x.ToString().Replace(",", ".") + ",  twist_angular_y="+ _y.ToString().Replace(",", ".") + ",  twist_angular_z=" + _z.ToString().Replace(",", ".") + "]";
            }
			
            public override string ToYAMLString() {
                return "\"twist_angular_x\" : " + _x.ToString().Replace(",", ".") + ", \"twist_angular_y\" : " + _y.ToString().Replace(",", ".") + ", \"twist_angular_z\" : " + _z.ToString().Replace(",", ".") ;
            }
        }
    }
}