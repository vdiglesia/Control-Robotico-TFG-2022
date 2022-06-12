using UnityEngine;

namespace RobotConnector.Scripts
{
    public class TestKinova : MonoBehaviour
    {
        public ROSInitializer rosObj;

        public string serviceName;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rosObj.CallService(serviceName,"");
            }
        }
    }
}