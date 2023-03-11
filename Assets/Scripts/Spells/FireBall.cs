using HP;
using UnityEngine;

namespace Spells
{
    public class FireBall : DamagingProjectile
    {
        [SerializeField] private int _fireDamage = -5;

        private new void Start()
        {
            base.Start();
            TypeOfElement = TypeOfElement.Fire;
        }
        protected override void PerformSpellAction(Health health)
        {
            if (Target is null) return;
            if (health.TypeOfElement == TypeOfElement)
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
