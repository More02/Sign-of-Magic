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
        }

        protected override void PerformSpellAction(Health health)
        {
            if (Target is null) return;
            _speed -= _lostOfValue;
            if (health.TypeOfElement == TypeOfElement)
            {
                health.ChangeHealth(DamageValue + _lostOfValue);
            }
            else
            {
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