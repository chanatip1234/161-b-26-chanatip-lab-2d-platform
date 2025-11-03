using System;
using UnityEngine;

public abstract class Enemy : character
{
    [Header("Enemy Settings")]
    public int DamageHit { get; protected set; }
    public float moveSpeed = 1.0f;

    protected Transform target; 

    protected virtual void Start()
    {
        base.Start();
       
        base.Initialize(50f); 
     
        target = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    protected virtual void FixedUpdate()
    {
      Behavior(); 
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

