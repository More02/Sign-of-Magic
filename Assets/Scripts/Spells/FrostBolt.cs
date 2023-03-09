using UnityEngine;

namespace Spells
{
    public class FrostBolt : DamagingProjectile
    {
        [SerializeField]
        private int _frostDamage;
    
        protected override void PerformSpellAction()
        {
            if (target is not null)
            {
                //TODO
            }
        }
    }
}
