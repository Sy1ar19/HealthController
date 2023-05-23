using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    [SerializeField] private int _healthBarChangeSpeed;

    private Coroutine _healthBarCoroutine;

    private void OnEnable()
    {
        _player.HealthChanged += UpdateHealthBar;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= UpdateHealthBar;
    }

    private void UpdateHealthBar(int health)
    {
        if (_healthBarCoroutine != null)
        {
            StopCoroutine(_healthBarCoroutine);
        }

        _healthBarCoroutine = StartCoroutine(ChangeHealthBarSmoothly(health));
    }


    private IEnumerator ChangeHealthBarSmoothly(int targetHealth)
    {
        float currentHealth = _slider.value;

        while (currentHealth != targetHealth)
        {
            currentHealth = Mathf.MoveTowards(currentHealth, targetHealth, _healthBarChangeSpeed * Time.deltaTime);
            _slider.value = currentHealth;

            yield return null;
        }

        _slider.value = targetHealth;

        _healthBarCoroutine = null;
    }
}
