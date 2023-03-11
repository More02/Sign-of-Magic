using UnityEngine;

namespace HP
{
    public struct DamageData
    {
        public float BaseDamage;
        public GameObject Target;
        public Color Color;

        public DamageData(float baseDamage, GameObject target, Color color)
        {
            BaseDamage = baseDamage;
            Target = target;
            Color = color;
        }
    }
}