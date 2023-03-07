using UnityEngine;

public static class Movement 
{
    public static void Move(Vector2 vectorFromHand, CharacterController characterController, float speed, Transform cameraTransform)
    {
        Vector3 vectorFromHandV3 = cameraTransform.right*(vectorFromHand.x) + cameraTransform.forward*(vectorFromHand.y);
        vectorFromHandV3.y = 0f;
        characterController.Move(vectorFromHandV3 * (speed * Time.deltaTime));
    }
}