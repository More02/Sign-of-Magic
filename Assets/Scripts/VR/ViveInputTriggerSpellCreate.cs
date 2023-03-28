using Spells;
using UnityEngine;
using Valve.VR;

namespace VR
{
    public class ViveInputTriggerSpellCreate : MonoBehaviour
    {
        [SerializeField] private SteamVR_Action_Boolean _grabPinch;

        [SerializeField] private GameObject _leftProjectile;
        [SerializeField] private GameObject _leftCast;

        [SerializeField] private GameObject _rightProjectile;
        [SerializeField] private GameObject _rightCast;

        private GameObject _leftSpell;
        private GameObject _rightSpell;
    
        private readonly SteamVR_Input_Sources _leftHand = SteamVR_Input_Sources.LeftHand;
        private readonly SteamVR_Input_Sources _rightHand = SteamVR_Input_Sources.RightHand;

        private float _leftTimer;
        private float _rightTimer;

        public GameObject LeftProjectile
        {
            set => _leftProjectile = value;
        }
        public GameObject LeftCast
        {
            set => _leftCast = value;
        }
        public GameObject RightProjectile
        {
            set => _rightProjectile = value;
        }
        public GameObject RightCast
        {
            set => _rightCast = value;
        }
        
        
        private Transform _leftSpellTransform;
        private Transform _rightSpellTransform;
    
        public Transform LeftSpellTransform
        {
            set => _leftSpellTransform = value;
        }
        public Transform RightSpellTransform
        {
            set => _rightSpellTransform = value;
        }

        private void Start()
        {
            _grabPinch.AddOnStateDownListener(OnLeftTriigerDown, _leftHand);
            _grabPinch.AddOnStateUpListener(OnLeftTriigerUp, _leftHand);
        
            _grabPinch.AddOnStateDownListener(OnRightTriigerDown, _rightHand);
            _grabPinch.AddOnStateUpListener(OnRightTriigerUp, _rightHand);
        }
    
        private void OnLeftTriigerDown(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource)
        {
            _leftTimer = Time.time;
            _leftSpell = CastSpell(_leftCast, _leftSpellTransform);
        }

        private void OnLeftTriigerUp(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource)
        {
            Destroy(_leftSpell);
            var spell = Instantiate(_leftProjectile, _leftSpellTransform.position + _leftSpellTransform.right.normalized * 0.5f, _leftSpellTransform.rotation);
            if (Time.time < _leftTimer + spell.GetComponent<ProjectileSpell>().TimeToCast) Destroy(spell);
            if (spell.TryGetComponent<TeleportationBall>(out var spellScript))
            {
                spellScript.Character = transform;
            }
            
        }
    
        private void OnRightTriigerDown(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource)
        {
            _rightTimer = Time.time;
            _rightSpell = CastSpell(_rightCast, _rightSpellTransform);
        }

        private void OnRightTriigerUp(SteamVR_Action_Boolean fromaction, SteamVR_Input_Sources fromsource)
        {
            Destroy(_rightSpell);
            var spell = Instantiate(_rightProjectile, _rightSpellTransform.position  + _rightSpellTransform.right.normalized * 0.5f, _rightSpellTransform.rotation);
            if (Time.time < _rightTimer + spell.GetComponent<ProjectileSpell>().TimeToCast) Destroy(spell);
        }
    
        private static GameObject CastSpell(GameObject spellCast, Transform castTransform)
        {
            var castSpell = Instantiate(spellCast, castTransform);
            return castSpell;
        }
    }
}
