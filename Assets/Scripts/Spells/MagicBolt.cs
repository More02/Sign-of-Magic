using UnityEngine;

namespace Spells
{
    public class MagicBolt : DamagingProjectile
    {    
        protected override void PerformSpellAction()
        {
            if (_target is not null)
            {
                //TODO
            }
        }
    }
}
