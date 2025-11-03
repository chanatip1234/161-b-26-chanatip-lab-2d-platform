using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Transform healthBarFill; // ตัว UI ที่ใช้แสดงเลือด

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public virtual void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    protected virtual void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            float healthPercent = currentHealth / maxHealth;
            healthBarFill.localScale = new Vector3(healthPercent, 1, 1);
        }
    }
    public void Initialize(float max)
    {
        maxHealth = max;
        currentHealth = max;
        UpdateHealthBar();
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

}
