using System.Collections;
using System.Text;
using SimpleJSON;
using ROSBridgeLib.geometry_msgs;

/* 
 * @brief ROSBridgeLib
 * @author Michael Jenkin, Robert Codd-Downey, Andrew Speers and Miquel Massot Campos
 */

namespace ROSBridgeLib {
	namespace geometry_msgs {
		public class Vector3Msg : ROSBridgeMsg {
			protected double _x;
			protected double _y;
			protected double _z;
			
			public Vector3Msg(JSONNode msg) {
				_x = double.Parse(msg["x"]);
				_y = double.Parse(msg["y"]);
				_z = double.Parse(msg["z"]);
			}
			
			public Vector3Msg(double x, double y, double z) {
				_x = x;
				_y = y;
				_z = z;
			}


			public static string GetMessageType() {
				return "geometry_msgs/Vector3";
			}
			
			public double GetX() {
				return _x;
			}
			
			public double GetY() {
				return _y;
			}
			
			public double GetZ() {
				return _z;
			}
			
			public override string ToString() {
				return "Vector3 [x=" + _x.ToString().Replace(",", ".") + ",  y="+ _y.ToString().Replace(",", ".") + ",  z=" + _z.ToString().Replace(",", ".") + "]";
			}
			
			public override string ToYAMLString() {
				return "{\"x\" : " + _x.ToString().Replace(",", ".") + ", \"y\" : " + _y.ToString().Replace(",", ".") + ", \"z\" : " + _z.ToString().Replace(",", ".") + "}";
			}
		}
	}
}