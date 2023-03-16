using HP;
using UnityEngine;

namespace Spells
{
    public class FireBall : DamagingProjectile
    {
        [SerializeField] private int _fireDamage = -5;
        private readonly Color _spellColor = new Color(1f, 0.61f, 0.11f);

        private new void Start()
        {
            base.Start();
            TypeOfElement = TypeOfElement.Fire;
        }

        protected override async void PerformSpellAction(Health health)
        {
            if (Target is null) return;
            if (!Target.transform.GetChild(0).GetChild(0).TryGetComponent<HealthBar>(out var healthBar)) return;
            var collisionPoint = Target.contacts[0].point;
            if (health.TypeOfElement == TypeOfElement)
            {
                health.ChangeHealth(DamageValue);
                await healthBar.CreateDamageText(new DamageData(DamageValue, collisionPoint, Color));
            }
            else
            {
                health.ChangeHealth(DamageValue);
                await healthBar.CreateDamageText(new DamageData(DamageValue, collisionPoint, Color));
                health.ChangeHealth(_fireDamage);
                await healthBar.CreateDamageText(new DamageData(_fireDamage, collisionPoint, _spellColor));
            }
        }
        
        private new void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);
            if (!collision.gameObject.TryGetComponent<Snow>(out var snow)) return;
            var water = Instantiate(snow.Water, collision.contacts[0].point, Quaternion.identity);
            snow.StartCoroutine(ILivable.LifeCoroutine(snow.WaterLifetime, water));
        }
    }
}