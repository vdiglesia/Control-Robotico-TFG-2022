/************************************************************************************

Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.

See SampleFramework license.txt for license terms.  Unless required by applicable law
or agreed to in writing, the sample code is provided “AS IS” WITHOUT WARRANTIES OR
CONDITIONS OF ANY KIND, either express or implied.  See the license for specific
language governing permissions and limitations under the license.

************************************************************************************/

using UnityEngine;

namespace Oculus.SampleFramework.Core.DistanceGrab.Scripts
{
    public class PauseOnInputLoss : MonoBehaviour
    {
        void Start()
        {
            OVRManager.InputFocusAcquired += OnInputFocusAcquired;
            OVRManager.InputFocusLost += OnInputFocusLost;
        }

        private void OnInputFocusLost()
        {
            Time.timeScale = 0.0f;
        }

        private void OnInputFocusAcquired()
        {
            Time.timeScale = 1.0f;
        }
    }
}
