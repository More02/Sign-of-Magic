using System.Collections;
using UnityEngine;

public interface ILifeCoroutine
{
    public static IEnumerator LifeCoroutine(float sec, GameObject gameObject)
    {
        yield return new WaitForSeconds(sec);

        MonoBehaviour.Destroy(gameObject);
    }
}