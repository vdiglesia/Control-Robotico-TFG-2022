/************************************************************************************

Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.  

************************************************************************************/

using UnityEngine;
using UnityEngine.EventSystems;

namespace Oculus.SampleFramework.Core.Video.Scripts
{
    public class ButtonDownListener : MonoBehaviour, UnityEngine.EventSystems.IPointerDownHandler
    {
        public event System.Action onButtonDown;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (onButtonDown != null)
            {
                onButtonDown.Invoke();
            }
        }
    }
}
