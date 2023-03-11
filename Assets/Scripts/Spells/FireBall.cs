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
            base.Start();
            TypeOfElement = TypeOfElement.Fire;
            Color = new Color(1f, 0.61f, 0.11f);
        }
        protected override void PerformSpellAction(Health health)
        {
            if (Target is null) return;
            if (health.TypeOfElement == TypeOfElement)
            {
                onSendDamage?.Invoke(new DamageData(DamageValue, 0, Target, TypeOfElement, Color));
                health.ChangeHealth(DamageValue);
            }
            else
            {
                onSendDamage?.Invoke(new DamageData(DamageValue, _fireDamage, Target, TypeOfElement, Color));
                health.ChangeHealth(DamageValue + _fireDamage);
            }
        }
    }
}
