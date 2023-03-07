using UnityEngine;
using Valve.VR;

public class HtcViveInput : MonoBehaviour
{
    private SteamVR_Input_Sources _hand;
    [SerializeField] 
    private SteamVR_Action_Vector2 _touchPos;
    [SerializeField] 
    private SteamVR_Action_Boolean _touchPad;
    [SerializeField] 
    private Transform _cameraTransform;

    private Vector2 _vectorFromHand = new Vector2(0, 0);
    private CharacterController _characterController;
    [SerializeField] 
    private float _speed = 12f;

    private bool _isClicked;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _touchPad.AddOnStateDownListener(GetTouchpadClickedDown, _hand);
        _touchPad.AddOnStateUpListener(GetTouchpadClickedUp, _hand);
        _touchPos.AddOnChangeListener(GetTouchpadPosition, _hand);
    }

    private void GetTouchpadClickedDown(SteamVR_Action_Boolean touchPad, SteamVR_Input_Sources hand)
    {
        _isClicked = _touchPad.GetState(_hand);
    }

    private void GetTouchpadClickedUp(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource)
    {
        _isClicked = false;
    }

    private void GetTouchpadPosition(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis,
        Vector2 delta)
    {
        if (!_isClicked) return;
        _vectorFromHand = _touchPos.GetAxis(_hand);
        if (((!(_vectorFromHand.y > 0.7f)) && (!(_vectorFromHand.y < -0.7f)) && (!(_vectorFromHand.x > 0.7f)) &&
             (!(_vectorFromHand.x < -0.7f)))) return;
        Movement.Move(_vectorFromHand, _characterController, _speed, _cameraTransform);
    }
}