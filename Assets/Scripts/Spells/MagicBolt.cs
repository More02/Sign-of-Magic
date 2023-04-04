using HP;
using UnityEngine;

namespace Spells
{
    public class MagicBolt : DamagingProjectile
    {
        protected override async void DealDamage(Health health)
        {
            if (health is null) return;
            var healthBar = health.transform.GetChild(0).GetChild(0).GetComponent<HealthBar>();
            if (healthBar is null) return;
            var collisionPoint = Target.contacts[0].point;
            //if (!Target.transform.GetChild(0).GetChild(0).TryGetComponent<HealthBar>(out var healthBar)) return;
            health.ChangeHealth(DamageValue);
            await healthBar.CreateDamageText(new DamageData(DamageValue, collisionPoint, Color));
        }
    }
}
