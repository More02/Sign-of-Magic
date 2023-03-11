using System;
using UnityEngine;
using UnityEngine.Events;
using VR;

namespace UI
{
   public class SkillButton : MonoBehaviour
   {
      [SerializeField] private GameObject _pointer;
      [SerializeField] private GameObject _spellProjectile;
      [SerializeField] private GameObject _spellCast;
      [SerializeField] private UnityEvent _onPress;
      [SerializeField] private UnityEvent _onRelease;
      
      private GameObject _presser;
      private bool _isPressed;

      private Transform _player;

      private void Start()
      {
         _player = transform.parent.parent.parent.parent;
         _isPressed = false;
      }

      private void OnTriggerEnter(Collider other)
      {
         if (!_isPressed)
         {
            _presser = other.gameObject;
            _onPress.Invoke();
            _isPressed = true;
         }
      }

      private void OnTriggerExit(Collider other)
      {
         if (other == _presser)
         {
            _onRelease.Invoke();
            _isPressed = false;
         }
      }

      public void ChangeSkill()
      {
         if (_player.TryGetComponent<ViveInputTriggerSpellCreate>(out var playerSpellClass))
         {
            _pointer.transform.position = transform.position;
            playerSpellClass.RightCast = _spellCast;
            playerSpellClass.RightProjectile = _spellProjectile;
         }
      }
   }
}
