using System;
using System.Threading.Tasks;
using UnityEngine;

namespace HP
{
    public class DamageNumber: MonoBehaviour
    {
        [SerializeField] private float _lifeTime = 2f;
        [SerializeField] private float _speed = 3f;
        private bool _flag;

        private async void Start()
        {
            _flag = true;
            await MoveUp();
            StartCoroutine(ILifeCoroutine.LifeCoroutine(_lifeTime, gameObject));
        }
        
        private async Task MoveUp()
        {
            while (_flag)
            {
                transform.Translate(Vector3.up * (_speed * Time.deltaTime));
            }
        }

        private void OnDestroy()
        {
            _flag = false;
        }
    }
}