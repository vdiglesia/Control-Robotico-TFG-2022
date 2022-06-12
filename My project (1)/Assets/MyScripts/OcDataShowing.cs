using TMPro;
using UnityEngine;

namespace MyScripts
{
    public class OcDataShowing : MonoBehaviour
    {
        public Transform leftTransf;
        public Transform rightTransf;
        public Transform headTransf;
        public TextMeshProUGUI leftPos;
        public TextMeshProUGUI leftRot;
        public TextMeshProUGUI rightPos;
        public TextMeshProUGUI rightRot;
        public TextMeshProUGUI headPos;
        public TextMeshProUGUI headRot;
        

        // Start is called before the first frame update
        private void ShowingData()
        {
            leftPos.text ="Position: " + leftTransf.position.ToString();
            leftRot.text ="Rotation: " + leftTransf.rotation.ToString();
            rightPos.text ="Position: " + rightTransf.position.ToString();
            rightRot.text ="Rotation: " + rightTransf.rotation.ToString();
            headPos.text = "Position: " + headTransf.rotation.ToString();
            headPos.text = "Rotation: " + headTransf.position.ToString();
        }
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        ShowingData();
        }
    }
}
