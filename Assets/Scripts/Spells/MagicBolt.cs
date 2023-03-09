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
                health.ChangeHealth(DamageValue);
            }
        }
    }
}
