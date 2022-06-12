using System;
using SGCore.Haptics;
using UnityEngine;

namespace MyScripts
{


    public class HapticsManager : MonoBehaviour
    {
        public GettingData gettingData;
        [Range(0,100)]
        public int ffbThumb, ffbIndex, ffbMiddle, ffbRing;
        [Range(0,100)]
        public int buzzThumb, buzzIndex;
        [Range(0, 100)] public int thumperIntensity;
        private SG_FFBCmd ffbCmd;
        private SG_BuzzCmd buzzCmd;
        private ThumperCmd thumperCmd;

        public void SliderFFBThumb(Single value)
        {
            int intValue = Convert.ToInt32(value);
            ffbThumb = intValue;
        }
        public void SliderFFBIndex(Single value)
        {
            int intValue = Convert.ToInt32(value);
            ffbIndex = intValue;
        }
        public void SliderFFBMiddle(Single value)
        {
            int intValue = Convert.ToInt32(value);
            ffbMiddle = intValue;
        }
        public void SliderFFBRing(Single value)
        {
            int intValue = Convert.ToInt32(value);
            ffbRing = intValue;
        }
        public void SliderBuzzThumb(Single value)
        {
            int intValue = Convert.ToInt32(value);
            buzzThumb = intValue;
        }
        public void SliderBuzzIndex(Single value)
        {
            int intValue = Convert.ToInt32(value);
            buzzIndex = intValue;
        }
        public void SliderThumper(Single value)
        {
            int intValue = Convert.ToInt32(value);
            thumperIntensity = intValue;
        }
        
        // Start is called before the first frame update
        void Start()
        {

        }
        // Update is called once per frame
        void Update()
        {   
            ffbCmd = new SG_FFBCmd(ffbThumb, ffbIndex, ffbMiddle, ffbRing, 0);
            buzzCmd = new SG_BuzzCmd(buzzThumb, buzzIndex, 0, 0, 0);
            thumperCmd = new ThumperCmd(thumperIntensity);
            gettingData.novaGlove.SendHaptics(ffbCmd,buzzCmd,thumperCmd);
        }
    }

}