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

         protected void PerformSpellAction()
        {
            if (_character is not null)
            {
                var teleportPoint = transform.position;
                teleportPoint.y += 1.8f;
                _character.position = teleportPoint;
            }
            else
            {
                Debug.Log("Null character error");
            }
        }
         
         protected override void PerformSpellAction(Health health)
        {
            throw new System.NotImplementedException();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Terrain"))
            {
                PerformSpellAction();
                Destroy(gameObject);
            }
        }

        
    }
}
