using UnityEngine;

public abstract class HealthBar : MonoBehaviour
{
    [SerializeField] protected Health Health;
    protected float MaxHealth;

    private void OnEnable()
    {
        if (Health != null)
        {
            Initialize(Health.MaxHealth);
            UpdateHealth(Health.CurrentHealth);
            Health.HealthChanged += UpdateHealth;
        }
    }

    private void OnDisable()
    {
        if (Health != null)
        {
            Health.HealthChanged -= UpdateHealth; 
        }
    }

    public void Initialize(float maxHealth)
    {
        MaxHealth = maxHealth;
    }

    private void UpdateHealth(float newHealth)
    {
        UpdateVisuals(newHealth / MaxHealth);
    }

    protected abstract void UpdateVisuals(float fillAmount);
}
