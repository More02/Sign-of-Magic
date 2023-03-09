using UnityEngine;

namespace Spells
{
    public class FireBall : DamagingProjectile
    {
        [SerializeField]
        private int _fireDamage;
        
        protected override void PerformSpellAction()
        {
            if (target is not null)
            {
                //TODO
            }
        }
    }
}
