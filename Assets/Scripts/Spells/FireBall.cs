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
            Debug.Log("in PerformSpellAction");
            if (Target is null) return;
            Debug.Log(Target.name);
            if (!Target.transform.GetChild(0).GetChild(0).TryGetComponent<HealthBar>(out var healthBar)) return;
            Debug.Log(healthBar.name);
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
