using UnityEngine;

namespace HP
{
    public struct DamageData
    {
        public float BaseDamage;
        public Vector3 Target;
        public Color Color;

        public DamageData(float baseDamage, Vector3 target, Color color)
        {
            BaseDamage = baseDamage;
            Target = target;
            Color = color;
        }
    }
}