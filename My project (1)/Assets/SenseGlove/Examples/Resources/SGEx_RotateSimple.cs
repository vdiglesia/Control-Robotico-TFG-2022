using SenseGlove.Scripts.Util;
using UnityEngine;

namespace SenseGlove.Examples.Resources
{
    /// <summary> A script to rotate an object around a specified axis </summary>
    public class SGEx_RotateSimple : MonoBehaviour
    {

        public SG_Util.MoveAxis moveAround = SG_Util.MoveAxis.Y;
        public float rotationSpeed = 10f;
        public bool resetOnEnable = false;

        public Quaternion OriginalRotation { get; protected set; }

        public void ResetRotation()
        {
            this.transform.rotation = OriginalRotation;
        }

        void Awake()
        {
            OriginalRotation = this.transform.rotation;
        }

        void OnEnable()
        {
            if (resetOnEnable) { ResetRotation(); }
        }

        // Update is called once per frame
        void Update()
        {
            float dAngle = Time.deltaTime * rotationSpeed;
            this.transform.rotation = this.transform.rotation * Quaternion.AngleAxis(dAngle, SG_Util.GetAxis(this.moveAround));
        }
    }
}