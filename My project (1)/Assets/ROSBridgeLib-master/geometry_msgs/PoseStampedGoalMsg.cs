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
        public class PoseStampedGoalMsg : ROSBridgeMsg {
            public HeaderMsg _header;
            public GoalIdMsg _GoalId;
            public PoseStampedMsg _goal;

            public PoseStampedGoalMsg(JSONNode msg) {
                _header = new HeaderMsg(msg["header"]);
                _GoalId = new GoalIdMsg(msg["goalId"]);
                _goal = new PoseStampedMsg(msg["pose"]);
            }
			
            public PoseStampedGoalMsg(Vector3 position, Quaternion rotation,string frameID, int sec, int nsec, int seq, string id) {
                _header = new HeaderMsg(seq, sec, nsec, "");
                _GoalId = new GoalIdMsg(seq, sec, nsec, id);
                _goal = new PoseStampedMsg(position,rotation,frameID,sec, nsec, seq);
            }

            public static string GetMessageType() {
                return "kinova_msgs/ArmPoseActionGoal";
            }
			
            public HeaderMsg GetHeader() {
                return _header;
            }


            public override string ToString() {
                return "PoseStamped [header=" + _header.ToString() + ",  goal_id=" + _GoalId.ToString() + ",  goal=" + _goal.ToString() + "]";
            }
			
            public override string ToYAMLString() {
                return "{\"header\" : " + _header.ToYAMLString() + ", \"goal_id\" : " + _GoalId.ToYAMLString() + ", \"goal\" : " + _goal.ToYAMLString() + "}";
            }
        }
    }
}
