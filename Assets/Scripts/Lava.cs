using System;
using HP;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Lava : MonoBehaviour
{
    [SerializeField] private GameObject _stone;
    [SerializeField] private int _lavaDamage = -5;
    private TypeOfElement _typeOfElement;
    private float _lastTick;
    private readonly float _tickTime = 1f;

    public GameObject Stone => _stone;

    private void Start()
    {
        _typeOfElement = TypeOfElement.Fire;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name);
        var health = other.gameObject.GetComponentInParent<Health>();
        if (health is null) return;
        if (Time.time < _lastTick + _tickTime) return;
        _lastTick = Time.time;
        DoLavaDamage(health);
    }

    private void DoLavaDamage(Health health)
    {
        health.ChangeHealth(health.TypeOfElement == _typeOfElement ? 0 : _lavaDamage);
    }
}