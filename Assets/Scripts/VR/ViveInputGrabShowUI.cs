using UnityEngine;
using Valve.VR;

namespace VR
{
    public class ViveInputGrabShowUI : MonoBehaviour
    {
        [SerializeField] private SteamVR_Action_Boolean _grabGrip;
        
        private readonly SteamVR_Input_Sources _hand = SteamVR_Input_Sources.LeftHand;

        private GameObject _switchingUI;

        public GameObject SwitchingUI
        {
            set => _switchingUI = value;
        }
        
        private void Start()
        {
            _grabGrip.AddOnStateDownListener(OnGrabGripClickedDown, _hand);
            _grabGrip.AddOnStateUpListener(OnGrabGripClickedUp, _hand);
        }
        
        private void OnGrabGripClickedDown(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource)
        {
            _switchingUI.SetActive(true);
        }
        
        private void OnGrabGripClickedUp(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource)
        {
            _switchingUI.SetActive(false);
        }
    }
}
