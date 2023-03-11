using HP;
using UnityEngine;

namespace Spells
{
    public class MagicBolt : DamagingProjectile
    {    
        protected override void PerformSpellAction(Health health)
        {
            if (Target is null) return;
            var healthBar = Target.GetComponent<HealthBar>();
            healthBar.CreateDamageText(new DamageData(DamageValue, Target, Color.white));
            health.ChangeHealth(DamageValue);
        }
    }
}
