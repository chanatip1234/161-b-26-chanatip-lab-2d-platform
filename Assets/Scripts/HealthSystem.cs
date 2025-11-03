using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("Health Bar UI")]
    public GameObject healthBarPrefab; 
    private Transform healthBarInstance;
    protected Transform healthBarFill;     

    protected virtual void Start()
    {
        currentHealth = maxHealth;
        CreateHealthBar(); 
        UpdateHealthBar();
    }

    
    private void CreateHealthBar()
    {
        if (healthBarPrefab != null)
        {
            GameObject bar = Instantiate(healthBarPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
            healthBarInstance = bar.transform;
            healthBarFill = healthBarInstance.Find("HealthBarBG/HealthBarFill");
        }
        else
        {
            Debug.LogWarning($"{name} has no HealthBar prefab assigned!");
        }
    }

   
    protected virtual void Update()
    {
        if (healthBarInstance != null)
        {
            healthBarInstance.position = transform.position + Vector3.up * 1.5f;
        }
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
