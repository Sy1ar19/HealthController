using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _minHealth = 0;
    private int _currentHealth = 100;

    public event Action<int> HealthChanged;

    private void Start()
    {
        UpdateHealth();
    }

    public void Heal(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth += amount, _minHealth, _maxHealth);
        UpdateHealth();
    }

    public void TakeDamage(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth -= amount , _minHealth, _maxHealth);
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        HealthChanged?.Invoke(_currentHealth);
    }  
}
