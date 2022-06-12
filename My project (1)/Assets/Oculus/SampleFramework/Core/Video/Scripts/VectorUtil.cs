/************************************************************************************

Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.  

************************************************************************************/

using UnityEngine;

namespace Oculus.SampleFramework.Core.Video.Scripts
{
    public static class VectorUtil {

        public static Vector4 ToVector(this Rect rect)
        {
            return new Vector4(rect.x, rect.y, rect.width, rect.height);
        }

    }
}
