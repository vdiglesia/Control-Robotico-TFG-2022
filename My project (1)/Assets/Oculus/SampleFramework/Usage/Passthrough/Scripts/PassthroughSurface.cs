using UnityEngine;

namespace Oculus.SampleFramework.Usage.Passthrough.Scripts
{
    public class PassthroughSurface : MonoBehaviour
    {
        public OVRPassthroughLayer passthroughLayer;
        public MeshFilter projectionObject;

        void Start()
        {
            Destroy(projectionObject.GetComponent<MeshRenderer>());
            passthroughLayer.AddSurfaceGeometry(projectionObject.gameObject, true);
        }
    }
}
