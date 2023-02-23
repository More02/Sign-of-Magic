using UnityEngine;

public static class Movement 
{
    public static void Move(Vector2 vectorFromHand, CharacterController characterController, float speed)
    {
        var vectorFromHandV3 = new Vector3(-vectorFromHand.x, 0, -vectorFromHand.y);
        characterController.Move(vectorFromHandV3 * (speed * Time.deltaTime));
    }
}