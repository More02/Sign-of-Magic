using HP;
using UnityEngine;

namespace Spells
{
    public class FrostBolt : DamagingProjectile
    {
        [SerializeField] private int _frostDamage = -4;
        [SerializeField] private int _lostOfValue = 2;
        protected new Color Color;

        private new void Start()
        {
            base.Start();
            TypeOfElement = TypeOfElement.Ice;
            Color = new Color(0.32f, 0.85f, 1f);
        }

        protected override async void PerformSpellAction(Health health)
        {
            if (Target is null) return;
            _speed -= _lostOfValue;
            var collisionPoint = Target.contacts[0].point;
            var healthBar = Target.gameObject.GetComponent<HealthBar>();
            if (health.TypeOfElement == TypeOfElement)
            {
                health.ChangeHealth(DamageValue + _lostOfValue);
                await healthBar.CreateDamageText(new DamageData(DamageValue + _lostOfValue, collisionPoint, base.Color));
            }
            else
            {
                health.ChangeHealth(DamageValue + _lostOfValue + _frostDamage);
                await healthBar.CreateDamageText(new DamageData(DamageValue + _lostOfValue, collisionPoint, base.Color));
                await healthBar.CreateDamageText(new DamageData(_frostDamage, collisionPoint, Color));
            }
        }

        private new void OnCollisionEnter(Collision collision)
        {
            base.OnCollisionEnter(collision);
            if (!collision.gameObject.TryGetComponent<Lava>(out var lava)) return;
            Instantiate(lava.Stone, collision.contacts[0].point, Quaternion.identity);
        }
    }
}