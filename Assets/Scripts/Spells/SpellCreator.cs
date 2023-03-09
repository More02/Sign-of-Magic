using System;
using UnityEngine;

namespace Spells
{
    public class SpellCreator : MonoBehaviour
    {
        [SerializeField] 
        private GameObject _spellPrefab;
        [SerializeField] 
        private Transform _castPoint;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                var spell = Instantiate(_spellPrefab, _castPoint.transform);
                if (spell.TryGetComponent<TeleportationBall>(out var spellScript))
                {
                    spellScript.Character = transform;
                }
                spell.transform.localScale = Vector3.one;
            }
        }
    }
}
