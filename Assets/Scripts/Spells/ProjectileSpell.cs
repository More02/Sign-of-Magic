using System.Collections;
using HP;
using UnityEngine;

namespace Spells
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class ProjectileSpell : MonoBehaviour
    {
        [SerializeField] private float _timeToCast = 1f;
        [SerializeField] private float _lifeTime = 10f;
        [SerializeField] protected float _speed = 50f;

        public float TimeToCast => _timeToCast;

        protected abstract void PerformSpellAction();

        protected void Start()
        {
            StartCoroutine(ILivable.LifeCoroutine(_lifeTime, gameObject));
            GetComponent<Rigidbody>().AddForce(transform.right.normalized * _speed, ForceMode.VelocityChange);
        }

        
    }
}