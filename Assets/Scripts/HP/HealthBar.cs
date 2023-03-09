using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace HP
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] 
        private Image _healthBarFilling;

        [SerializeField] private TextMeshPro _healthCountText;
        [SerializeField] 
        private Gradient _gradient;
    
        private Health _health;

        private void Awake()
        {
            _health = transform.parent.parent.GetComponent<Health>();
            _health.HealthChanged += OnHealthChanged;
            _healthBarFilling.color = _gradient.Evaluate(1);
            _healthCountText.color = _gradient.Evaluate(1);
        }

        private void OnDestroy()
        {
            _health.HealthChanged -= OnHealthChanged;
        }
    
        private void OnHealthChanged(HealthData healthData )
        {
            _healthBarFilling.fillAmount = healthData.CurrentHealthAsPercange;
            _healthBarFilling.color = _gradient.Evaluate(healthData.CurrentHealthAsPercange);
        
            _healthCountText.color = _gradient.Evaluate(healthData.CurrentHealthAsPercange);
            _healthCountText.text = healthData.CurrentHealth.ToString(CultureInfo.InvariantCulture);
        }
    }
}
