using System;
using HP;
using UnityEngine;

namespace Spells
{
    public abstract class DamagingProjectile : ProjectileSpell
    {
        [SerializeField] protected int DamageValue = -15;
        protected TypeOfElement TypeOfElement;
        protected Color Color = new Color(0.82f, 0.09f, 1f);

        protected Collision Target;

        protected void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Health>(out var health))
            {
                Target = collision;
                PerformSpellAction(health);
            }
            Destroy(gameObject);
        }
    }
}
