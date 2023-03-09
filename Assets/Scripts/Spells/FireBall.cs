using HP;
using UnityEngine;

namespace Spells
{
    public class FireBall : DamagingProjectile
    {
        [SerializeField]
        private int _fireDamage = -5;

        private new void Start()
        {
            TypeOfElement = TypeOfElement.Fire;
        }
        protected override void PerformSpellAction(Health health)
        {
            if (Target is null) return;
            if (Target.GetComponent<Health>().TypeOfElement == TypeOfElement)
            {
                health.ChangeHealth(DamageValue);
            }
            else
            {
                health.ChangeHealth(DamageValue + _fireDamage);
            }
        }
    }
}
