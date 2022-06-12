using UnityEngine;

namespace RobotConnector.Scripts
{
    public class DebugTransform : MonoBehaviour
    {

        public string debug;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            debug = "position: \n" +
                    "x: " + transform.position.x + "\n" +
                    "y: " + transform.position.y + "\n" +
                    "z: " + transform.position.z + "\n" +
                    "orientation: \n" +
                    "x: " + transform.rotation.x + "\n" +
                    "y: " + transform.rotation.y + "\n" +
                    "z: " + transform.rotation.x + "\n" +
                    "w: " + transform.rotation.w + "\n";
        }
    }
}
