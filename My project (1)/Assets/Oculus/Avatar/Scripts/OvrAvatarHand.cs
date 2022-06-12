namespace Oculus.Avatar.Scripts
{
    public class OvrAvatarHand : OvrAvatarComponent
    {
        public bool isLeftHand = true;
        ovrAvatarHandComponent component = new ovrAvatarHandComponent();

        void Update()
        {
            if (owner == null)
            {
                return;
            }

            bool hasComponent = false;
            if (isLeftHand)
            {
                hasComponent = CAPI.ovrAvatarPose_GetLeftHandComponent(owner.sdkAvatar, ref component);
            }
            else
            {
                hasComponent = CAPI.ovrAvatarPose_GetRightHandComponent(owner.sdkAvatar, ref component);
            }

            if (hasComponent)
            {
                UpdateAvatar(component.renderComponent);
            }
            else
            {
                if (isLeftHand)
                {
                    owner.HandLeft = null;

                }
                else
                {
                    owner.HandRight = null;
                }

                Destroy(this);
            }
        }
    }
}
