using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace MyScripts
{
    public class VirtualRobot : MonoBehaviour
    {
        public Transform brazoIzq;
        [Range(0f, 100f)] public int aperturaManual, aperturaTarget;

        public float currentApertura;
        private int anteriorAp = 0;
        public Transform brazoDer;
        public Transform pinza;
        public float speedMovement, speedRotation;
        private float xPos, yPos, zPos;
        public Vector3 targetPosition, targetRotation;
        private float[] aperturaArray = new float[2];

        public void SetPosition(float xPos, float yPos, float zPos)
        {
            pinza.transform.position = new Vector3(xPos, yPos, zPos);
        }

        public void Movimiento()
        {
            float paso = speedMovement * Time.deltaTime;
            pinza.transform.position = Vector3.MoveTowards(GetPosition(), targetPosition, paso);
        }

        public void MovimientoApertura(float aperturaTarget)
        {
            float current = GetApertura();
            float paso = speedRotation * Time.deltaTime;
            
            if (current > aperturaTarget)
            {
                float newApertura = Mathf.Clamp(current - paso, aperturaTarget, 100f);
                SetApertura(newApertura);
            }
            else if (current < aperturaTarget)
            {
                float newApertura = Mathf.Clamp(current + paso, 0, aperturaTarget);
                SetApertura(newApertura);
            }
        }

        public Vector3 GetPosition()
        {
            return pinza.position;
        }

        public float GetApertura()
        {
            float apertura = (brazoDer.localEulerAngles.x) - (270f);
            return apertura * 100f / 70f;
            
        }

        public void SetApertura(float apertura)
        {
            float rot = 70f * apertura / 100f;

            brazoDer.localEulerAngles = new Vector3(-90f + rot, 0f, -15f);
            brazoIzq.localEulerAngles = new Vector3(-20f - rot, 0f, -15f);
        }

        // Start is called before the first frame update
        void Start()
        {
            GetApertura();
            brazoIzq.localEulerAngles = new Vector3(-20, 0, -15);
            brazoDer.localEulerAngles = new Vector3(-90, 0, -15);
        }

        // Update is called once per frame
        void Update()
        {
            MovimientoApertura(aperturaTarget);
            Movimiento();
            currentApertura = GetApertura();
            //SetApertura(aperturaManual);
        }
    }
}