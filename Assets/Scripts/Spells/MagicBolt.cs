using HP;
using UnityEngine;

namespace Spells
{
    public class MagicBolt : DamagingProjectile
    {    
        protected override async void PerformSpellAction(Health health)
        {
            if (Target is null) return;
            var healthBar = Target.gameObject.GetComponent<HealthBar>();
            await healthBar.CreateDamageText(new DamageData(DamageValue, Target, Color.white));
            health.ChangeHealth(DamageValue);
        }
    }
}
