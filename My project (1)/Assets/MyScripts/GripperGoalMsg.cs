using System.Collections;
using System.Text;
using SimpleJSON;
using ROSBridgeLib.geometry_msgs;
using ROSBridgeLib.std_msgs;
using UnityEngine;

/* 
 * @brief ROSBridgeLib
 * @author Alejandro Langarica. FUCK YOU!!
 */

namespace ROSBridgeLib
{
    namespace geometry_msgs
    {
        public class GripperGoalMsg : ROSBridgeMsg
        {
            public HeaderMsg _header;
            public GoalIdMsg _GoalId;
            public GrippPosition _goal;

            public GripperGoalMsg(JSONNode msg) {
                _header = new HeaderMsg(msg["header"]);
                _GoalId = new GoalIdMsg(msg["goalId"]);
                _goal = new GrippPosition(msg["fingers"]);
            }
			
            public GripperGoalMsg(float position, float maxEffort, string frameID, int sec, int nsec, int seq, string id) {
                _header = new HeaderMsg(seq, sec, nsec, "");
                _GoalId = new GoalIdMsg(seq, sec, nsec, id);
                _goal = new GrippPosition(position, maxEffort);
            }

            public static string GetMessageType() {
                return "kinova_msgs/FingersPositionGoal";
            }
			
            public HeaderMsg GetHeader() {
                return _header;
            }


            public override string ToString() {
                return "PoseStamped [header=" + _header.ToString() + ",  goal_id=" + _GoalId.ToString() + ",  fingers=" + _goal.ToString() + "]";
            }
			
            public override string ToYAMLString() {
                return "{\"header\" : " + _header.ToYAMLString() + ", \"goal_id\" : " + _GoalId.ToYAMLString() + ", \"goal\" : " + _goal.ToYAMLString() + "}";
            }
        }
    }
}