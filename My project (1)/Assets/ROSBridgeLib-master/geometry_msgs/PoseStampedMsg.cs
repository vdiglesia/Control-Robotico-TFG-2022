using System.Collections;
using System.Text;
using SimpleJSON;
using ROSBridgeLib.std_msgs;
using UnityEngine;

/* 
 * @brief ROSBridgeLib
 * @author Michael Jenkin, Robert Codd-Downey, Andrew Speers and Miquel Massot Campos
 */

namespace ROSBridgeLib {
	namespace geometry_msgs {
		public class PoseStampedMsg : ROSBridgeMsg {
			public HeaderMsg _header;
			public PoseMsg _pose;

			public PoseStampedMsg(JSONNode msg) {
				_header = new HeaderMsg(msg["header"]);
				_pose = new PoseMsg(msg["pose"]);
			}
			
			public PoseStampedMsg(Vector3 position, Quaternion rotation,string frameID, int sec, int nsec, int seq) {
				_header = new HeaderMsg(seq, sec, nsec, frameID);
				_pose = new PoseMsg(position,rotation);
			}

			public static string GetMessageType() {
				return "geometry_msgs/PoseStamped";
			}
			
			public HeaderMsg GetHeader() {
				return _header;
			}

			public PoseMsg GetPose() {
				return _pose;
			}
			
			public override string ToString() {
				return "PoseStamped [header=" + _header.ToString() + ",  pose=" + _pose.ToString() + "]";
			}
			
			public override string ToYAMLString() {
				return "{\"pose\" : {\"header\" : " + _header.ToYAMLString() + ", \"pose\" : " + _pose.ToYAMLString() + "}}";
			}
		}
	}
}