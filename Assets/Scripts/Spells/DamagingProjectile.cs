using UnityEngine;

namespace Spells
{
    public abstract class DamagingProjectile : ProjectileSpell
    {
        [SerializeField] 
        private int _damageValue;

        private GameObject _target;

        protected override void PerformSpellAction()
        {
            if (_target is not null)
            {
                //TODO
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            //TODO
        }
    }
}
