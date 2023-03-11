using HP;
using UnityEngine;

namespace Spells
{
    public class FrostBolt : DamagingProjectile
    {
        [SerializeField] private int _frostDamage = -4;
        [SerializeField] private int _lostOfValue = 2;

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
            var healthBar = Target.gameObject.GetComponent<HealthBar>();
            if (health.TypeOfElement == TypeOfElement)
            {
                await healthBar.CreateDamageText(new DamageData(DamageValue + _lostOfValue, Target, Color.white));
                health.ChangeHealth(DamageValue + _lostOfValue);
            }
            else
            {
                await healthBar.CreateDamageText(new DamageData(DamageValue + _lostOfValue, Target, Color.white));
                await healthBar.CreateDamageText(new DamageData(_frostDamage, Target, Color));
                health.ChangeHealth(DamageValue + _lostOfValue + _frostDamage);
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