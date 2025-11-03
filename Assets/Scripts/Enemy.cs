using System;
using UnityEngine;

public abstract class Enemy : character
{
    [Header("Enemy Settings")]
    public int DamageHit { get; protected set; }
    public float moveSpeed = 1.0f;

    protected Rigidbody2D rb;
    protected Transform target; // player

    protected virtual void Start()
    {
        // เรียก initialize จาก character (สืบทอดมาจาก HealthSystem)
        base.Intialize(50f); // เลือดเริ่มต้นของศัตรู

        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    protected virtual void FixedUpdate()
    {
      Behavior(); // เรียกพฤติกรรมเฉพาะของศัตรูแต่ละตัว
    }

    public void OnHitWith(Player player)
    {
        player.TakeDamage(DamageHit);
    }

    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            OnHitWith(player);
        }
    }
    public abstract void Behavior();
    

}

