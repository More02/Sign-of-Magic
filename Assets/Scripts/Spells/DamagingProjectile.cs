using UnityEngine;

namespace Spells
{
    public abstract class DamagingProjectile : ProjectileSpell
    {
        [SerializeField] 
        private int _damageValue;

        protected GameObject _target;

        private void OnCollisionEnter(Collision collision)
        {
            //TODO
        }
    }
}
