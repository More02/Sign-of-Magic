using HP;
using UnityEngine;

namespace Spells
{
    public class MagicBolt : DamagingProjectile
    {    
        protected new Color Color;
        protected override async void PerformSpellAction(Health health)
        {
            if (Target is null) return;
            var collisionPoint = Target.contacts[0].point;
            var healthBar = Target.gameObject.GetComponent<HealthBar>();
            health.ChangeHealth(DamageValue);
            await healthBar.CreateDamageText(new DamageData(DamageValue, collisionPoint, base.Color));
        }
    }
}
