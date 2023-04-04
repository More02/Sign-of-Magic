using System.Collections;
using UnityEngine;

public interface ILivable
{
    static IEnumerator LifeCoroutine(float sec, GameObject gameObject)
    {
        yield return new WaitForSeconds(sec);

        MonoBehaviour.Destroy(gameObject);
    }
}