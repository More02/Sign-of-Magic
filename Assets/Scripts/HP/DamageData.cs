using UnityEngine;

namespace HP
{
    public struct DamageData
    {
        public float BaseDamage;
        public Collision Target;
        public Color Color;

        public DamageData(float baseDamage, Collision target, Color color)
        {
            BaseDamage = baseDamage;
            Target = target;
            Color = color;
        }
    }
}