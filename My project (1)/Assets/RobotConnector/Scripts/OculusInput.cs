using UnityEngine;

namespace RobotConnector.Scripts
{
    public class OculusInput : MonoBehaviour
    {
        public float TriggerL;
        public float TriggerR;

        public float gripL;
        public float gripR;

        public bool button1L;
        public bool button2L;
        public bool button3L;
        public bool button1R;
        public bool button2R;
        public bool button3R;

        public Vector2 lJoy;
        public Vector2 rJoy;
    
        public bool buttonJoyL;
        public bool buttonJoyR;
    
    
    
        // Start is called before the first frame update
        void Start()
        {
        
        

        }

        // Update is called once per frame
        void Update()
        {

            TriggerL = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
            TriggerR = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);

            gripL = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
            gripR = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
        
            lJoy = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.LTouch);
            rJoy = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.RTouch); 
        
            button1L = OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.LTouch);
            button2L = OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.LTouch);
            button3L = OVRInput.Get(OVRInput.Button.Three, OVRInput.Controller.LTouch);
            buttonJoyL = OVRInput.Get(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.LTouch);
        
            button1R = OVRInput.Get(OVRInput.Button.One, OVRInput.Controller.RTouch);
            button2R = OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch);
            button3R = OVRInput.Get(OVRInput.Button.Three, OVRInput.Controller.RTouch);
            buttonJoyR = OVRInput.Get(OVRInput.Button.PrimaryThumbstick, OVRInput.Controller.RTouch);
        
            /*m_animator.SetFloat("Button 1", OVRInput.Get(OVRInput.Button.One, m_controller) ? 1.0f : 0.0f);
        m_animator.SetFloat("Button 2", OVRInput.Get(OVRInput.Button.Two, m_controller) ? 1.0f : 0.0f);
        m_animator.SetFloat("Button 3", OVRInput.Get(OVRInput.Button.Start, m_controller) ? 1.0f : 0.0f);

        m_animator.SetFloat("Joy X", OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, m_controller).x);
        m_animator.SetFloat("Joy Y", OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, m_controller).y);

        m_animator.SetFloat("Trigger", OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, m_controller));
        m_animator.SetFloat("Grip", OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, m_controller));*/
        }
    }
}
