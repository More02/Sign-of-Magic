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

        protected override async void DealDamage(Health health)
        {
            if (health is null) return;
            var healthBar = health.transform.GetChild(0).GetChild(0).GetComponent<HealthBar>();
            if (healthBar is null) return;
            //if (!Target.transform.GetChild(0).GetChild(0).TryGetComponent<HealthBar>(out var healthBar)) return;
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
            var contactPoint = collision.contacts[0].point - collision.contacts[0].normal.normalized * 0.25f;
            var water = Instantiate(snow.Water,contactPoint , Quaternion.LookRotation(contactPoint,collision.contacts[0].normal));
            snow.StartCoroutine(ILivable.LifeCoroutine(snow.WaterLifetime, water));
        }
    }
}