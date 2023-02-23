using System;
using UnityEngine;
using UnityEngine.Serialization;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class HtcViveInput : MonoBehaviour
{
    private SteamVR_Input_Sources _hand;
    [FormerlySerializedAs("TouchPos")] [SerializeField]
    private SteamVR_Action_Vector2 _touchPos;

    private Vector2 _vectorFromHand =  new Vector2(0, 0);
    private CharacterController _characterController;
    [SerializeField]
    private float _speed = 12f;
    
    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private Vector2 GetTrackPadPos()
    {
        Debug.Log(_touchPos.GetAxis(_hand));
        _vectorFromHand = _touchPos.GetAxis(_hand);
        return _touchPos.GetAxis(_hand);
    }

    public void Update()
    {
        //Vector3 vectorFromHandV3 = new Vector3(vectorFromHand.x, 0, vectorFromHand.y);
        GetTrackPadPos();
        if ((!(_vectorFromHand.y > 0.7f)) && (!(_vectorFromHand.y < -0.7f)) && (!(_vectorFromHand.x > 0.7f)) &&
            (!(_vectorFromHand.x < -0.7f))) return;
        _characterController.Move(_vectorFromHand * (_speed * Time.deltaTime));
        print("Moving");
        //getTrackPadPos();
    }
}
