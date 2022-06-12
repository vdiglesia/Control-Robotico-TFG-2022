using UnityEngine;

namespace MyScripts
{
    public class GlovesWithOculus : MonoBehaviour
    {
        public Transform quest2Left;
        public Transform quest2Right;

        public Transform leftGlove;
        public Transform rightGlove;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        private void LinkingVRTransforms()
        {
            leftGlove.transform.position = quest2Left.transform.position;
            leftGlove.transform.position = quest2Left.transform.position;
            leftGlove.transform.rotation = quest2Left.transform.rotation;
            rightGlove.transform.position = quest2Right.transform.position;
            rightGlove.transform.rotation = quest2Right.transform.rotation;
        }
        // Update is called once per frame
        void Update()
        {   
            LinkingVRTransforms();
        
        }
    }
}
