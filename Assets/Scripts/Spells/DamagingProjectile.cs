using System;
using HP;
using UnityEngine;
using UnityEngine.Analytics;

namespace Spells
{
    public abstract class DamagingProjectile : ProjectileSpell
    {
        [SerializeField] protected int DamageValue = -15;
        [SerializeField] private GameObject _explosionSpell;
        protected TypeOfElement TypeOfElement;
        protected Color Color = new Color(0.82f, 0.09f, 1f);
        private bool _hited;
        
        private bool _castEnd;

        protected Collision Target;

        public void Casted()
        {
            _castEnd = true;
        }
        
        protected abstract void DealDamage(Health health);
        
        protected override void PerformSpellAction()
        {
            DealDamage(Target.gameObject.GetComponentInParent<Health>());
        }

        protected void OnCollisionEnter(Collision collision)
        {
            //if (collision.gameObject.TryGetComponent<Health>(out var health))
            if (_hited) return;
            Target = collision;
            PerformSpellAction();
            Destroy(gameObject);
            _hited = true;
        }

        private void OnDestroy()
        {
            if (_castEnd) Instantiate(_explosionSpell, transform.position, Quaternion.identity);
        }
    }
}
