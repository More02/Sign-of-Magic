using System;
using HP;
using UnityEngine;

public class Lava : MonoBehaviour
{
    [SerializeField] public GameObject Stone;
    [SerializeField] private int _lavaDamage = -5;
    private TypeOfElement _typeOfElement;
    private float _lastTick;
    private readonly float _tickTime = 1f;

    private new void Start()
    {
        _typeOfElement = TypeOfElement.Fire;
    }

    protected void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.TryGetComponent<Health>(out var health)) return;
        if (Time.time < _lastTick + _tickTime) return;
        _lastTick = Time.time;
        DoLavaDamage(health);
    }

    private void DoLavaDamage(Health health)
    {
        health.ChangeHealth(health.TypeOfElement == _typeOfElement ? 0 : _lavaDamage);
    }
}