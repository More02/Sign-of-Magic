using System.Collections;
using HP;
using UnityEngine;

namespace Spells
{
    public class TeleportationBall : ProjectileSpell
    {
        private Transform _character;
        
        public Transform Character
        {
            set => _character = value;
        }

        protected override void PerformSpellAction(Health health)
        {
            if (_character is not null)
            {
                var teleportPoint = transform.position;
                teleportPoint.y += _character.GetComponent<CharacterController>().height / 2;
                _character.position = teleportPoint;
            }
            else
            {
                Debug.Log("Null character error");
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Terrain"))
            {
                PerformSpellAction(_character.GetComponent<Health>());
                Destroy(gameObject);
            }
        }

        
    }
}
