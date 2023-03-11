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
        protected override void PerformSpellAction(Health health)
        {
            if (Target is null) return;
            var healthBar = Target.GetComponent<HealthBar>();
            if (health.TypeOfElement == TypeOfElement)
            {
                healthBar.CreateDamageText(new DamageData(DamageValue, Target, Color.white));
                health.ChangeHealth(DamageValue);
            }
            else
            {
                healthBar.CreateDamageText(new DamageData(DamageValue, Target, Color.white));
                healthBar.CreateDamageText(new DamageData(_fireDamage, Target, Color));
                health.ChangeHealth(DamageValue + _fireDamage);
            }
        }
    }
}
