using System.Globalization;
using Spells;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HP
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _healthBarFilling;

        [SerializeField] private TextMeshPro _healthCountText;
        [SerializeField] private GameObject _damageTextPrefab;

        [SerializeField] private Gradient _gradient;

        private Health _health;
        private DamagingProjectile _damagingProjectile;

        private void Awake()
        {
            _health = transform.parent.parent.GetComponent<Health>();
            _health.onHealthChanged += OnHealthChanged;
            _healthBarFilling.color = _gradient.Evaluate(1);
            _healthCountText.color = _gradient.Evaluate(1);
        }

        private void OnDestroy()
        {
            _health.onHealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged(HealthData healthData)
        {
            _healthBarFilling.fillAmount = healthData.CurrentHealthAsPercange;
            _healthBarFilling.color = _gradient.Evaluate(healthData.CurrentHealthAsPercange);

            _healthCountText.color = _gradient.Evaluate(healthData.CurrentHealthAsPercange);
            _healthCountText.text = healthData.CurrentHealth.ToString(CultureInfo.InvariantCulture);
        }

        public void CreateDamageText(DamageData damageData)
        {
            var damageTextObject = Instantiate(_damageTextPrefab, damageData.Target.transform);
            var damageText = damageTextObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>();
            damageText.text = damageData.BaseDamage.ToString(CultureInfo.InvariantCulture);
            damageText.color = damageData.Color;
        }
        
    }
}