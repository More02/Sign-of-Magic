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

        protected Collision Target;
        
        protected abstract void DealDamage(Health health);
        
        protected override void PerformSpellAction()
        {
            DealDamage(Target.gameObject.GetComponentInParent<Health>());
        }

        protected void OnCollisionEnter(Collision collision)
        {
            //if (collision.gameObject.TryGetComponent<Health>(out var health))
            
            Target = collision;
            PerformSpellAction();
            Destroy(gameObject);
        }

        private void OnDestroy()
        {
            var exp = Instantiate(_explosionSpell, transform.position, Quaternion.identity);
        }
    }
}
