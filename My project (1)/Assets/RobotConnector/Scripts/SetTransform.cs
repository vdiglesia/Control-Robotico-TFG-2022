using UnityEngine;

namespace RobotConnector.Scripts
{
    public class SetTransform : MonoBehaviour
    {
        public bool work;

        public Vector3 position;

        public Quaternion rotation;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (!work) return;
            transform.position = position;
            transform.rotation = rotation;
        }
    }
}
