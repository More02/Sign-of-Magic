using HP;
using UnityEngine;

namespace Spells
{
    public class FireBall : DamagingProjectile
    {
        [SerializeField] private int _fireDamage = -5;
        protected new Color Color;

        private new void Start()
        {
            base.Start();
            TypeOfElement = TypeOfElement.Fire;
            Color = new Color(1f, 0.61f, 0.11f);
        }
        protected override async void PerformSpellAction(Health health)
        {
            if (Target is null) return;
            if (!Target.transform.GetChild(0).GetChild(0).TryGetComponent<HealthBar>(out var healthBar)) return;
            var collisionPoint = Target.contacts[0].point;
            if (health.TypeOfElement == TypeOfElement)
            {
                health.ChangeHealth(DamageValue);
                await healthBar.CreateDamageText(new DamageData(DamageValue, collisionPoint, base.Color));
            }
            else
            {
                health.ChangeHealth(DamageValue + _fireDamage);
                await healthBar.CreateDamageText(new DamageData(DamageValue, collisionPoint, base.Color));
                await healthBar.CreateDamageText(new DamageData(_fireDamage, collisionPoint, Color));
            }
        }
    }
}
