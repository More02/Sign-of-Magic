using HP;
using UnityEngine;

namespace Spells
{
    public class MagicBolt : DamagingProjectile
    {    
        protected override void PerformSpellAction(Health health)
        {
            if (Target is not null)
            {
                onSendDamage?.Invoke(new DamageData(DamageValue, 0, Target, TypeOfElement, Color));
                health.ChangeHealth(DamageValue);
            }
        }
    }
}
