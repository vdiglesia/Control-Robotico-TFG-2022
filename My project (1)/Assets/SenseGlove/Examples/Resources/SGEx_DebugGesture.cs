﻿using SenseGlove.Scripts.Tracking;
using UnityEngine;
using UnityEngine.UI;

namespace SenseGlove.Examples.Resources
{

	public class SGEx_DebugGesture : MonoBehaviour
	{
		public SG_GestureLayer gestureLayer;
		public SG_BasicGesture gestureToCheck;
		public Text exampleText;

		public string lStr = "";

		// Update is called once per frame
		void Update()
		{
			
			if (gestureToCheck && gestureLayer)
            {
				lStr = "Gesturing: " + (gestureToCheck.IsGesturing ? "True" : "False");
				lStr += "\r\n" + gestureToCheck.ToRangeString(gestureLayer.lastFlexions);
				if (exampleText != null)
				{
					exampleText.text = lStr;
				}
			}
		}
	}

}