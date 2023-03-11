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
        [SerializeField] private TextMeshPro _baseDamageText;
        [SerializeField] private TextMeshPro _extraDamageText;
        
        [SerializeField] private Gradient _gradient;

        private Health _health;
        private DamagingProjectile _damagingProjectile;

        private void Awake()
        {
            _health = transform.parent.parent.GetComponent<Health>();
            _health.onHealthChanged += OnHealthChanged;
            // _damagingProjectile = GetComponent<>...
            _damagingProjectile.onSendDamage += OnSendDamage;
            _healthBarFilling.color = _gradient.Evaluate(1);
            _healthCountText.color = _gradient.Evaluate(1);
        }

        private void OnDestroy()
        {
            _health.onHealthChanged -= OnHealthChanged;
            _damagingProjectile.onSendDamage -= OnSendDamage;
        }

        private void OnHealthChanged(HealthData healthData)
        {
            _healthBarFilling.fillAmount = healthData.CurrentHealthAsPercange;
            _healthBarFilling.color = _gradient.Evaluate(healthData.CurrentHealthAsPercange);

            _healthCountText.color = _gradient.Evaluate(healthData.CurrentHealthAsPercange);
            _healthCountText.text = healthData.CurrentHealth.ToString(CultureInfo.InvariantCulture);
        }

        private void OnSendDamage(DamageData damageData)
        {
            _baseDamageText.text = damageData.BaseDamage.ToString(CultureInfo.InvariantCulture);
            _baseDamageText.color = Color.white;
            
            if (damageData.ExtraDamage == 0) return;
            _extraDamageText.text = damageData.ExtraDamage.ToString(CultureInfo.InvariantCulture);
            _extraDamageText.color = damageData.Color;
        }
    }
}