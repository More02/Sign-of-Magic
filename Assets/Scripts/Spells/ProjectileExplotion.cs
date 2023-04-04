using System;
using UnityEngine;

namespace Spells
{
    public class ProjectileExplotion : MonoBehaviour
    {
        [SerializeField] private float _lifeTime = 2f;

        private void Start()
        {
            StartCoroutine(ILivable.LifeCoroutine(_lifeTime, gameObject));
        }
    }
}