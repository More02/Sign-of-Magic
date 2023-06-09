using System.Globalization;
using System.Threading.Tasks;
using Spells;
using TMPro;
using UI;
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

        private bool _isLastHit = false;

        private Health _health;
        private CameraPositionTracker _cameraPositionTracker;
        private HealthData _healthData;
        private DamagingProjectile _damagingProjectile;
        private Vector3 _vectorToUIRotate;

        private void Awake()
        {
            var parent = transform.parent.parent;
            _health = parent.GetComponent<Health>();
            _health.onHealthChanged += OnHealthChanged;
            _healthBarFilling.color = _gradient.Evaluate(1);
            _healthCountText.color = _gradient.Evaluate(1);
            _cameraPositionTracker = parent.GetComponent<CameraPositionTracker>();
            _cameraPositionTracker.onOnCameraPositionChanged += OnRotateUI;
        }

        private void OnDestroy()
        {
            _health.onHealthChanged -= OnHealthChanged;
            _cameraPositionTracker.onOnCameraPositionChanged -= OnRotateUI;
        }

        private void OnHealthChanged(HealthData healthData)
        {
            _healthData = healthData;
            _healthBarFilling.fillAmount = healthData.CurrentHealthAsPercange;
            _healthBarFilling.color = _gradient.Evaluate(healthData.CurrentHealthAsPercange);

            _healthCountText.color = _gradient.Evaluate(healthData.CurrentHealthAsPercange);
            _healthCountText.text = healthData.CurrentHealth.ToString(CultureInfo.InvariantCulture);
        }

        public async Task CreateDamageText(DamageData damageData)
        {
            if (_isLastHit) return;
            if ((_healthData.CurrentHealth <= 0))
            {
                _isLastHit = true;
            }

            var damageTextObject = Instantiate(_damageTextPrefab, damageData.Target,
                Quaternion.LookRotation(transform.position - _vectorToUIRotate, Vector3.up));
            damageTextObject.transform.SetParent(transform);
            var damageText = damageTextObject.transform.GetChild(0).GetChild(0).GetComponent<TextMeshPro>();
            damageText.text = damageData.BaseDamage.ToString(CultureInfo.InvariantCulture);
            damageText.color = damageData.Color;
            await Task.Delay(150);
        }

        private void OnRotateUI(Vector3 newUIPosition)
        {
            _vectorToUIRotate = newUIPosition;
            var position = transform.position;
            transform.rotation = Quaternion.LookRotation(position - newUIPosition, Vector3.up);
        }
    }
}