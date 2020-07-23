using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UnityEngine;

public class BaseStats : ScriptableObject
{
    [SerializeField] protected float _damage;
    [SerializeField] protected float _maxHealth;
    [SerializeField] float _health;
    public float Damage
    {
        get => _damage;
    }
    public float MaxHealth { get => _maxHealth; }
    public float Health
    { 
        get => _health;
        set
        {
            if (value >= 0 && value <= _maxHealth)
            {
                _health = value;
            }
        }
    }
}
