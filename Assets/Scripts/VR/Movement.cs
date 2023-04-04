using UnityEngine;

namespace VR
{
    public static class Movement 
    {
        public static void Move(Vector2 vectorFromHand, Transform playerTransform, float speed, Transform cameraTransform)
        {
            Vector3 vectorFromHandV3 = cameraTransform.right*(vectorFromHand.x) + cameraTransform.forward*(vectorFromHand.y);
            if (vectorFromHandV3.y > -0.5) vectorFromHandV3.y = 0f;
            playerTransform.Translate(vectorFromHandV3 * (speed * Time.deltaTime));
        }
    }
}