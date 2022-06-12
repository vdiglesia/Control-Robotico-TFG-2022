using System.Collections;
using System.Text;
using SimpleJSON;
using UnityEngine;

/**
 * Define a header message. These have been hand-crafted from the corresponding msg file.
 * 
 * Version History
 * 
 * @author Michael Jenkin, Robert Codd-Downey and Andrew Speers
 * @version 3.0
 */

namespace ROSBridgeLib {
    namespace std_msgs {
        public class GoalIdMsg : ROSBridgeMsg {
            private TimeMsg _stamp;
            private string _id;
			
            public GoalIdMsg(JSONNode msg) {
                //Debug.Log ("HeaderMsg with " + msg.ToString ());
                
                _stamp = new TimeMsg (msg ["stamp"]);
                _id = msg["id"];
                //Debug.Log ("HeaderMsg done ");
                //Debug.Log (" and it looks like " + this.ToString ());
            }
			
            public GoalIdMsg(TimeMsg stamp, string id) {
                
                _stamp = stamp;
                _id = id;
            }

            public GoalIdMsg(int seq, int sec, int nsec, string id)
            {
                _stamp = new TimeMsg(sec, nsec);
                _id = id;
            }

            public static string GetMessageType() {
                return "std_msgs/GoalId";
            }


            public TimeMsg GetTimeMsg() {
                return _stamp;
            }

            public string GetFrameId() {
                return _id;
            }
			
            public override string ToString() {
                return "Header [stamp=" + _stamp + ", id=" + _id + "]";
            }
			
            public override string ToYAMLString() {
                return "{\"stamp\" : " + _stamp.ToYAMLString () + ", \"id\" : \"" + _id + "\"}";
            }
        }
    }
}