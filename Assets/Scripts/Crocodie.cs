using UnityEngine;

public class Crocodie : Enemy , IShoottable
{
    [SerializeField] private float atkRange;
    public Player player; //target to atk

    [field : SerializeField] public GameObject Bullet { get ; set ; }
    [field : SerializeField] public Transform ShootPoint { get ; set ; }
    public float ReloadTime { get ; set ; }
    public float WaitTime { get ; set ; }

    void Start()
    {
        base.Initialize(50);
        DamageHit = 30;
        //set atk range and target
        atkRange = 6.0f;
        player = GameObject.FindFirstObjectByType<Player>();
        anim = GetComponent<Animator>();
        WaitTime = 0.0f;
        ReloadTime = 5.0f;
    }

    private void FixedUpdate()
    {
        WaitTime += Time.fixedDeltaTime; 
        Behavior();
    }
    public override void Behavior()
    {
        if (player == null)
            return;

        Vector2 distance = transform.position - player.transform.position;
        if (distance.magnitude <= atkRange)
        {
            Debug.Log($"{player.name} is in the {this.name}'s atk range!");
            Shoot();
        }
    }
    public void Shoot()
    {
        if (WaitTime >= ReloadTime)
        {
            anim.SetTrigger("Shoot");
            var bullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
            Rock rock = bullet.GetComponent<Rock>();
            rock.Initweapon(30, this);
            WaitTime = 0;
        }
    }
}


