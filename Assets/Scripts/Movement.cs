using UnityEngine;
using Valve.VR;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Movement : MonoBehaviour
{
    // SteamVR_TrackedObject trackedObj;
    // SteamVR_Controller.Device device;
    //
    // void Awake()
    // {
    //     trackedObj = GetComponent<SteamVR_TrackedObject>();
    // }
    //
    // void FixedUpdate()
    // {
    //     device = SteamVR_Controller.Input((int)trackedObj.index);
    // }
    //
    // void Update()
    // {
    //     if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis1))
    //     {
    //     }
    //     else if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis2))
    //     {
    //     }
    //
    //     if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis3))
    //     {
    //     }
    //
    //     if (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis4))
    //     {
    //     }
    //     // Vector2 touchpad = (device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
    //     // print("Pressing Touchpad");
    //     //
    //     // if (touchpad.y > 0.7f)
    //     // {
    //     //     print("Moving Up");
    //     // }
    //     //
    //     // else if (touchpad.y < -0.7f)
    //     // {
    //     //     print("Moving Down");
    //     // }
    //     //
    //     // if (touchpad.x > 0.7f)
    //     // {
    //     //     print("Moving Right");
    //     //
    //     // }
    //     //
    //     // else if (touchpad.x < -0.7f)
    //     // {
    //     //     print("Moving left");
    //     // }
    // }
}