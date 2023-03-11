using UnityEngine;

namespace HP
{
    public class DamageData
    {
        public float BaseDamage;
        public float ExtraDamage;
        public GameObject Target;
        public TypeOfElement TypeOfElement;
        public Color Color;

        public DamageData(float baseDamage, float extraDamage, GameObject target, TypeOfElement typeOfElement, Color color)
        {
            BaseDamage = baseDamage;
            ExtraDamage = extraDamage;
            Target = target;
            TypeOfElement = typeOfElement;
            Color = color;
        }
    }
}