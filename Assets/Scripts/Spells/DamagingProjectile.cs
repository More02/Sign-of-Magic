using System;
using HP;
using UnityEngine;

namespace Spells
{
    public abstract class DamagingProjectile : ProjectileSpell
    {
        [SerializeField] protected int DamageValue = -15;
        protected TypeOfElement TypeOfElement;
        protected Color Color = Color.clear;

        protected Collision Target;

        protected void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent<Health>(out var health)) return;
            Target = collision;
            PerformSpellAction(health);
        }
    }
}
