using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

namespace VR
{
    public class ViveInputGrab : MonoBehaviour
    {
        [SerializeField] private SteamVR_Action_Boolean _grabGrip;
        
        private readonly SteamVR_Input_Sources _leftHand = SteamVR_Input_Sources.LeftHand;
        private readonly SteamVR_Input_Sources _rightHand = SteamVR_Input_Sources.RightHand;

        private GameObject _switchingUI;

        private UnityEvent _firstSkillEvent;
        private UnityEvent _secondSkillEvent;
        private UnityEvent _thirdSkillEvent;
        private int _skillState;

        public UnityEvent FirstSkillEvent
        {
            set => _firstSkillEvent = value;
        }
        public UnityEvent SecondSkillEvent
        {
            set => _secondSkillEvent = value;
        }
        public UnityEvent ThirdSkillEvent
        {
            set => _thirdSkillEvent = value;
        }
        
        public GameObject SwitchingUI
        {
            set => _switchingUI = value;
        }
        
        private void Start()
        {
            _grabGrip.AddOnStateDownListener(OnGrabGripClickedDown, _leftHand);
            _grabGrip.AddOnStateUpListener(OnGrabGripClickedUp, _leftHand);
            
            _grabGrip.AddOnStateDownListener(OnGrabGripRightClickedDown, _rightHand);

            _skillState = 1;
        }

        private void OnGrabGripRightClickedDown(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource)
        {
            StopAllCoroutines();
            _switchingUI.SetActive(true);
            
            if (_skillState == 1)
            {
                _secondSkillEvent.Invoke();
                _skillState = 2;
                
            }
            else if (_skillState == 2)
            {
                _thirdSkillEvent.Invoke();
                _skillState = 3;
            }
            else
            {
                _firstSkillEvent.Invoke();
                _skillState = 1;
            }
            
            StartCoroutine(ShowUIForSeconds(2));
        }
        
        private void OnGrabGripClickedDown(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource)
        {
            _switchingUI.SetActive(true);
        }
        
        private void OnGrabGripClickedUp(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource)
        {
            _switchingUI.SetActive(false);
        }

        private IEnumerator ShowUIForSeconds(float sec)
        {            
            yield return new WaitForSeconds(sec);
            
            _switchingUI.SetActive(false);
        }
    }
}
