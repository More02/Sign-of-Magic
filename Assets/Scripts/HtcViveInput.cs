using UnityEngine;
using Valve.VR;

public class HtcViveInput : MonoBehaviour
{
    private SteamVR_Input_Sources _hand;
    [SerializeField] 
    private SteamVR_Action_Vector2 _touchPos;
    [SerializeField] 
    private SteamVR_Action_Boolean _touchPad;

    private Vector2 _vectorFromHand = new Vector2(0, 0);
    private CharacterController _characterController;
    [SerializeField] 
    private float _speed = 12f;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    
    private Vector2 GetTrackPadPos()
    {
        _vectorFromHand = _touchPos.GetAxis(_hand);
        return _touchPos.GetAxis(_hand);
    }

    private bool GetTouchPad()
    {
        return _touchPad.GetState(_hand);
    }

    public void Update()
    {
        if (!GetTouchPad()) return;
        GetTrackPadPos();
        if (((!(_vectorFromHand.y > 0.7f)) && (!(_vectorFromHand.y < -0.7f)) && (!(_vectorFromHand.x > 0.7f)) &&
             (!(_vectorFromHand.x < -0.7f)))) return;
        var vectorFromHandV3 = new Vector3(-_vectorFromHand.x, 0, -_vectorFromHand.y);
        _characterController.Move(vectorFromHandV3 * (_speed * Time.deltaTime));
        print("Moving");
    }
}