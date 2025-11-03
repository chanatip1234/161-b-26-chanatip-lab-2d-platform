using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    public int damage;

    public IShoottable Shooter;


    public abstract void Move();

    public abstract void OnHitWith(character character);

    public void Initweapon(int newDamage, IShoottable newShooter)
    {
        damage = newDamage;
        Shooter = newShooter;
    }

    public int GetShootDirection()
    {
        float value = Shooter.ShootPoint.position.x - Shooter.ShootPoint.parent.position.x;

        if (value > 0)
            return 1;
        else return -1;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        character character = other.GetComponent<character>();
        if (character == null)
        {
            OnHitWith(character);
            Destroy(this.gameObject, 5f);
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
