using UnityEngine;

public class character : HealthSystem
{
    protected Animator anim;
    protected Rigidbody2D rb;

    protected override void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        CreateHealthBar();
    }

    public void SetupCharacter(float startHealth)
    {
        Initialize(startHealth);
        Debug.Log($"{name} initialized with health {currentHealth}");
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage); // เรียกจาก HealthSystem → อัปเดต bar อัตโนมัติ
        Debug.Log($"{name} took {damage} damage. Current HP: {currentHealth}");

        if (IsDead())
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log($"{name} has died.");
        Destroy(gameObject);
    }

    private void CreateHealthBar()
    {
        if (healthBarPrefab == null)
        {
            Debug.LogWarning($"{name} has no HealthBar prefab assigned!");
            return;
        }

        GameObject hb = Instantiate(healthBarPrefab, transform.position + new Vector3(0, 1.5f, 0), Quaternion.identity, transform);
        hb.transform.localPosition = new Vector3(0, 1.5f, 0);
        hb.transform.localScale = Vector3.one * 0.01f;

        Transform fill = hb.transform.Find("Fill");
        if (fill != null)
        {
            healthBarFill = fill;
        }
    }
}
