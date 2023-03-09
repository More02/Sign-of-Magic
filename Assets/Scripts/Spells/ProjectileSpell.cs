using System.Collections;
using UnityEngine;

namespace Spells
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class ProjectileSpell : MonoBehaviour
    {
        [SerializeField]
        private float _lifeTime = 10f;
        [SerializeField]
        protected float _speed = 15f;

        protected abstract void PerformSpellAction();

        protected void Start()
        {
            StartCoroutine(LifeCoroutine(_lifeTime));
            GetComponent<Rigidbody>().AddForce(transform.right.normalized * _speed, ForceMode.VelocityChange);
        }
        
        private IEnumerator LifeCoroutine(float sec)
        {
            yield return new WaitForSeconds(sec);
            
            Destroy(gameObject);
        }
    }
}
