using UnityEngine;

namespace MyScripts
{
    public class VRRig : MonoBehaviour
    {
        public Transform quest2Left;

        public Transform quest2Right;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            quest2Left.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch);
            quest2Right.localPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTouch);
            quest2Left.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch);
            quest2Right.localRotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);

        }
    }
}
