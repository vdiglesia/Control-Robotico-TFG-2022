using UnityEngine;
using TMPro;

namespace MyScripts
{


    public class UIShowing : MonoBehaviour
    {
        //Inicializacion
        public GettingData gettingData;
        public TextMeshProUGUI deviceText;
        public TextMeshProUGUI thumbsText;
        public TextMeshProUGUI indexText;
        public TextMeshProUGUI middleText;
        public TextMeshProUGUI ringText;
        public TextMeshProUGUI iMUText;
        public TextMeshProUGUI batteryText;
        

        private void PrintDataUI()
        {
            thumbsText.text = "Thumbs: " + gettingData.sensorValueDictionary["Thumb"];
            indexText.text = "Index: " + gettingData.sensorValueDictionary["Index"];
            middleText.text = "Middle: " + gettingData.sensorValueDictionary["Middle"];
            ringText.text = "Ring: " + gettingData.sensorValueDictionary["Ring"];
            iMUText.text = "IMU: " + gettingData.sensorValueDictionary["IMU Rotation Data"];
            batteryText.text = "Batería: " + gettingData.sensorValueDictionary["Battery Level"];


        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            deviceText.text = "Dispositivo: \n" + gettingData.novaGlove.GetDeviceID();
            PrintDataUI();

        }
    }
}