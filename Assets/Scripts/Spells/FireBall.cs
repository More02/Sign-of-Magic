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
            Color = new Color(1f, 0.61f, 0.11f);
        }
        protected override async void PerformSpellAction(Health health)
        {
            if (Target is null) return;
            if (!Target.transform.GetChild(0).GetChild(0).TryGetComponent<HealthBar>(out var healthBar)) return;
            if (health.TypeOfElement == TypeOfElement)
            {
                await healthBar.CreateDamageText(new DamageData(DamageValue, Target, Color.white));
                health.ChangeHealth(DamageValue);
            }
            else
            {
                await healthBar.CreateDamageText(new DamageData(DamageValue, Target, Color.white));
                await healthBar.CreateDamageText(new DamageData(_fireDamage, Target, Color));
                health.ChangeHealth(DamageValue + _fireDamage);
            }

        }
    }
}
