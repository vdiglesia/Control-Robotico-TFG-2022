
using System.Collections;
using SGCore.Kinematics;
using System.Collections.Generic;
using SGCore.Nova;
using UnityEngine;


namespace MyScripts
{


    public class GettingData : MonoBehaviour
    { //inicialización
        public NovaGlove novaGlove;
        private static Vect3D[] values = new Vect3D[5];
        //Variables Sensor
        public static Vect3D[] sensorValues = new Vect3D[5];
        public float[] sensorValuesFloat = new float[5];
        private static Quat imu;
        private static int sNumber;
        private static bool imuCompleted;
        private static float battery;
        private static bool charging;
        SGCore.Nova.Nova_SensorData sensor = new Nova_SensorData(sensorValues, sNumber,imu, imuCompleted,battery,charging);
        public IDictionary sensorValueDictionary = new Dictionary<string, string>(); 

        public static void PrintCalibrationValues()
        {
            foreach (var value in values)
            {
                print(value.x +" x "+ value.y+" y " + value.z+" z ");
            } 
        }

        public static void SensorDataCollectorUpdater(Nova_SensorData sensor, IDictionary sensorValueDictionary)
        {
            if (sensorValueDictionary.Contains("Thumb") || sensorValueDictionary.Contains("Index"))
            {
                sensorValueDictionary["Thumb"] = sensor.SensorValues[0].ToString();
                sensorValueDictionary["Index"] = sensor.SensorValues[1].ToString();
                sensorValueDictionary["Middle"] = sensor.SensorValues[2].ToString();
                sensorValueDictionary["Ring"] = sensor.SensorValues[3].ToString();
                sensorValueDictionary["Battery Level"] = sensor.BatteryLevel.ToString();
                sensorValueDictionary["IMU Rotation Data"] = sensor.IMURotation.ToString();
            }
            else
            {
                sensorValueDictionary.Add("Thumb", sensor.SensorValues[0].ToString());
                sensorValueDictionary.Add("Index", sensor.SensorValues[1].ToString());
                sensorValueDictionary.Add("Middle", sensor.SensorValues[2].ToString());
                sensorValueDictionary.Add("Ring", sensor.SensorValues[3].ToString());
                sensorValueDictionary.Add("Battery Level", sensor.BatteryLevel.ToString("##.0 %"));
                sensorValueDictionary.Add("IMU Rotation Data", sensor.IMURotation.ToString());
            }
        }

        
        private void Components()
        {   
            NovaGlove.GetNovaGlove(out novaGlove);
            // print(novaGlove.GetDeviceType());
            novaGlove.GetCalibrationValues(out values);
            novaGlove.GetSensorData(out sensor);
        }

        // Start is called before the first frame update
        void Start()
        {  Components();
            PrintCalibrationValues();
        }

        // Update is called once per frame
        void Update()
        {
            try
            {
                sensorValuesFloat[0] = sensor.SensorValues[0].y;
                sensorValuesFloat[1] = sensor.SensorValues[1].y;
                sensorValuesFloat[2] = sensor.SensorValues[2].y;
                sensorValuesFloat[3] = sensor.SensorValues[3].y;
            }
            catch
            {
                
            }

            
            
            
            
            novaGlove.GetSensorData(out sensor);
            //SensorDataCollectorUpdater(sensor, sensorValueDictionary);
        }
    }
}