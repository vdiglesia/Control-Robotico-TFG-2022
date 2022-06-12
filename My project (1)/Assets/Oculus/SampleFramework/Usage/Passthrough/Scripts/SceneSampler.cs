using UnityEngine;
using UnityEngine.SceneManagement;

namespace Oculus.SampleFramework.Usage.Passthrough.Scripts
{
    public class SceneSampler : MonoBehaviour
    {
        int currentSceneIndex = 0;
        public GameObject displayText;

        void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        void Update()
        {
            bool controllersActive = OVRInput.GetActiveController() == OVRInput.Controller.Touch ||
                                     OVRInput.GetActiveController() == OVRInput.Controller.LTouch ||
                                     OVRInput.GetActiveController() == OVRInput.Controller.RTouch;

            displayText.SetActive(controllersActive);

            if (OVRInput.GetUp(OVRInput.Button.Start))
            {
                currentSceneIndex++;
                if (currentSceneIndex >= SceneManager.sceneCountInBuildSettings) currentSceneIndex = 0;
                SceneManager.LoadScene(currentSceneIndex);
            }

            Vector3 menuPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch) + Vector3.up * 0.09f;
            displayText.transform.position = menuPosition;
            displayText.transform.rotation = Quaternion.LookRotation(menuPosition - Camera.main.transform.position);
        }
    }
}
