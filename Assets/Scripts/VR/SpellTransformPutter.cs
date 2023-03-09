using UnityEngine;

namespace VR
{
    public class SpellTransformPutter : MonoBehaviour
    {
        [SerializeField] 
        private Transform _spellTransform;

        private void Start()
        {
            var player = transform.parent.parent;
        }
    }
}
