using UnityEngine;

namespace VR
{
    public class SpellTransformPutter : MonoBehaviour
    {
        [SerializeField] 
        private Transform _spellTransform;

        private void Start()
        {
            if (transform.parent.parent.parent.parent.TryGetComponent<ViveInputTriggerSpellCreate>(out var playerSpellClass))
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

            
        }
    }
}
