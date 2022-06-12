using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace MyScripts
{
    public class Connector : MonoBehaviour
    {
        public GettingData data;
        public Transform handPosition;
        public float multiplicador;
        public VirtualRobot pinza;
        public Vector3 desplazamiento;
    
        private float _pinzaValue;
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            _pinzaValue = GetPinzaValue();
            SetValues();
        }

        private float GetPinzaValue()
        {
            float thumb = (data.sensorValuesFloat[0] - 500f) / 18;
            float index = (data.sensorValuesFloat[1] + 500f) / 22;

            return 100f-((thumb + index) / 2f);
        }


        private void SetValues()
        {
            pinza.aperturaTarget = (int)_pinzaValue;
            pinza.targetPosition = handPosition.position*multiplicador + desplazamiento;
        }
    
    
    }
}
