using UnityEngine;

public class Player : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _minHealth = 0;
    private int _currentHealth = 100;

    public delegate void HealthChangedHandler(int currentHealth);
    public event HealthChangedHandler OnHealthChanged;

    private void Start()
    {
        GetCurrentHealth();
    }

    public void Heal(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth += amount, _minHealth, _maxHealth);
        GetCurrentHealth();
    }

    public void TakeDamage(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth -= amount , _minHealth, _maxHealth);
        GetCurrentHealth();
    }

    public void GetCurrentHealth()
    {
        OnHealthChanged?.Invoke(_currentHealth);
    }  
}
