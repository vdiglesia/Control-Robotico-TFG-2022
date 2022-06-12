using System.IO;
using Oculus.SampleFramework.Core.DebugUI.Scripts;
using UnityEngine;

// Create menu of all scenes included in the build.
namespace Oculus.SampleFramework.Usage.StartScene.Scripts
{
    public class StartMenu : MonoBehaviour
    {   
        public global::OVROverlay overlay;
        public global::OVROverlay text;
        public OVRCameraRig vrRig;

        void Start()
        {
            DebugUIBuilder.instance.AddLabel("Select Sample Scene");
        
            int n = UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings;
            for (int i = 0; i < n; ++i)
            {
                string path = UnityEngine.SceneManagement.SceneUtility.GetScenePathByBuildIndex(i);
                var sceneIndex = i;
                DebugUIBuilder.instance.AddButton(Path.GetFileNameWithoutExtension(path), () => LoadScene(sceneIndex));
            }
        
            DebugUIBuilder.instance.Show();
        }

        void LoadScene(int idx)
        {
            DebugUIBuilder.instance.Hide();
            Debug.Log("Load scene: " + idx);
            UnityEngine.SceneManagement.SceneManager.LoadScene(idx);
        }
    }
}
