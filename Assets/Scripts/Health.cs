using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] string _damageTag;
    [SerializeField] BaseStats _stats;
    [SerializeField] BaseStats _targetStats;

    void Start()
    {
        _stats.Health = _stats.MaxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_damageTag))
        {
            TakeDamage(_targetStats.Damage);
        }
    }

    private void TakeDamage(float damage)
    {
        _stats.Health = Mathf.Clamp(_stats.Health - damage, 0, _stats.MaxHealth);
        if (_stats.Health == 0)
        {
            SendMessage("HandleDeath");
        }
    }
}
