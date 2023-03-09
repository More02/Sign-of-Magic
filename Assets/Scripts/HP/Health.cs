using System;
using UnityEngine;

namespace HP
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;
        private int _currentHealth;
        [SerializeField] public TypeOfElement TypeOfElement;

        public event Action<HealthData> onHealthChanged;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        public void ChangeHealth(int value)
        {
            _currentHealth += value;
            if (_currentHealth <= 0)
            {
                _currentHealth = 0;
                Death();
            }
            else if (_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
                InvokeHealthChanged();
            }
            else
            {
                InvokeHealthChanged();
            }
        }

        private void Death()
        {
            var healthData = new HealthData(0, 0);
            onHealthChanged?.Invoke(healthData);
        }

        private void InvokeHealthChanged()
        {
            var currentHealthAsPercange = (float)_currentHealth / _maxHealth;
            var healthData = new HealthData(currentHealthAsPercange, _currentHealth);
            onHealthChanged?.Invoke(healthData);
        }
    }
}