using System;
using UnityEngine;

namespace HP
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int _maxHealth = 100;
        private int _currentHealth;

        public event Action<HealthData> HealthChanged;

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ChangeHealth(-20);
            }
        }

        private void ChangeHealth(int value)
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
            HealthData healthData = new HealthData(0, 0);
            HealthChanged?.Invoke(healthData);
        }

        private void InvokeHealthChanged()
        {
            float currentHealthAsPercange = (float)_currentHealth / _maxHealth;
            HealthData healthData = new HealthData(currentHealthAsPercange, _currentHealth);
            HealthChanged?.Invoke(healthData);
        }
    }
}