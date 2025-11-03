using UnityEngine;

public class character : HealthSystem
{

    private int heath;

    public int Heath
    {
        get { return heath; }
        set { heath = (value < 0) ? 0 : value; }
    }
    protected Animator anim;
    protected Rigidbody2D rb;


    public void Intialize (int startHeath)
    {
        Heath = startHeath;
        Debug.Log($"{this.name} is intialize Heath : {this.Heath}");

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }




    public void  TakeDamage(int damage)
    {
        Heath -= damage;
        Debug.Log($"{this.name} took damage {damage}. Current Heath : {Heath}");

        IsDead();
    }
    public bool IsDead()
    {
        if (heath <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else { return false; };
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
