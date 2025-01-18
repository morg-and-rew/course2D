using System;
using UnityEngine;

public class Health : MonoBehaviour, ITakingDamage
{
    private float _maxHealth = 100f;
    [SerializeField]private float _currentHealth;

    public float MaxHealth => _maxHealth;
    public float CurrentHealth => _currentHealth;

    public event Action<float> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
        HealthChanged?.Invoke(_currentHealth);
    }

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _currentHealth -= damage;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            HealthChanged?.Invoke(_currentHealth);
        }
    }

    public void TakeHeal(float amount)
    {
        if (amount > 0)
        {
            _currentHealth += amount;
            _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);
            HealthChanged?.Invoke(_currentHealth);
        }
    }
}