using System;
using UnityEngine;
using UnityEngine.Events;
using VR;

namespace UI
{
   public class SkillButton : MonoBehaviour
   {
      [SerializeField] private Transform _root;
      [SerializeField] private GameObject _pointer;
      [SerializeField] private GameObject _spellProjectile;
      [SerializeField] private GameObject _spellCast;
      
      public UnityEvent _onPress;
      public UnityEvent _onRelease;

      private GameObject _presser;
      private bool _isPressed;

      private Transform _player;

      private void Start()
      {
         _player = _root.parent.parent.parent.parent;
         _isPressed = false;

         if (_player.TryGetComponent<ViveInputGrab>(out var playerGrab))
         {
            if (name.Contains("1")) playerGrab.FirstSkillEvent = _onPress;
            else if (name.Contains("2")) playerGrab.FirstSkillEvent = _onPress;
            else if (name.Contains("3")) playerGrab.FirstSkillEvent = _onPress;
         }
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
         if (other.gameObject == _presser)
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
