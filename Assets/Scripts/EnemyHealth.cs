using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] string _damageTag;
    [SerializeField] BaseStats _stats;
    [SerializeField] BaseStats _playerStats;

    private float _health;

    void Start()
    {
        _health = _stats.MaxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_damageTag))
        {
            TakeDamage(_playerStats.Damage);
        }
    }

    private void TakeDamage(float damage)
    {
        _health = Mathf.Clamp(_health - damage, 0, _stats.MaxHealth);
        if (_health == 0)
        {
            SendMessage("HandleDeath");
        }
    }
}
