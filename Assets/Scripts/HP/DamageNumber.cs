using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace HP
{
    public class DamageNumber: MonoBehaviour
    {
        [SerializeField] private float _lifeTime = 2f;
        [SerializeField] private float _speed = 1f;

        private async void Start()
        {
            await MoveUp();
            Destroy(gameObject);
            //StartCoroutine(LifeCoroutine(_lifeTime));
        }
        
        private async Task MoveUp()
        {
            var nowTime = 0f;
            while (nowTime < _lifeTime)
            {
                transform.Translate(Vector3.up * (_speed * Time.deltaTime));
                nowTime += Time.deltaTime;
                await Task.Yield();
            }
        }

        private IEnumerator LifeCoroutine(float sec)
        {
            yield return new WaitForSeconds(sec);

            Destroy(gameObject);
        }
    }
}