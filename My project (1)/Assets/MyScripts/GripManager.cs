using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace MyScripts
{
    public class GripManager : MonoBehaviour
    {
        public GettingData data;
        public float multiplicador;
        public KinovaFingersController kinova;
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
            kinova.position =1- (int) _pinzaValue;
        }
    
    
    }
}