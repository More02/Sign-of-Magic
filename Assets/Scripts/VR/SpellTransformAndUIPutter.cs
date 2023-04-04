using UnityEngine;

namespace VR
{
    public class SpellTransformAndUIPutter : MonoBehaviour
    {
        [SerializeField] private Transform _spellTransform;
        [SerializeField] private GameObject _switchingUI;

        private void Start()
        {
            var player = transform.parent.parent.parent.parent;
            if (player.TryGetComponent<ViveInputTriggerSpellCreate>(out var playerSpellClass))
            {
                if (gameObject.name.Contains("left"))
                {
                    playerSpellClass.LeftSpellTransform = _spellTransform;
                }
                else
                {
                    playerSpellClass.RightSpellTransform = _spellTransform;
                }
            }
            
            if (player.TryGetComponent<ViveInputGrab>(out var playerGrabClass))
            {
                if (gameObject.name.Contains("right"))
                {
                    playerGrabClass.SwitchingUI = _switchingUI;
                }
            }

            
        }
    }
}
