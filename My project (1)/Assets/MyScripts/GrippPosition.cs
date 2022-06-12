using System.Collections;
using System.Text;
using SimpleJSON;
using ROSBridgeLib.std_msgs;
using UnityEngine;

/* 
 * @brief ROSBridgeLib
 * @author Michael Jenkin, Robert Codd-Downey, Andrew Speers and Miquel Massot Campos
 */

namespace ROSBridgeLib
{
    namespace geometry_msgs
    {
        public class GrippPosition : ROSBridgeMsg
        {
            private float _position, _maxEffort;
            public GrippPosition(JSONNode msg) {
                _position = float.Parse(msg["x"]);
                _maxEffort = float.Parse(msg["y"]);
            }
			
            public GrippPosition(float position, float maxEffort)
            {
                _position = position;
                _maxEffort = maxEffort;
            }

            public static string GetMessageType() {
                return "geometry_msgs/FingerPosition";
            }

            public override string ToString() {
                return "geometry_msgs/command [position=" + _position.ToString().Replace(",", ".") + ",  max_effort=" + _maxEffort.ToString().Replace(",", ".")  + "]";
            }
					
            public override string ToYAMLString() {
                return   "{\"command\" : "+ "{\"position\": " + _position.ToString().Replace(",", ".") + ", \"max_effort\": " + _maxEffort.ToString().Replace(",", ".") + "}}";
            }
        }
    }
}