using UnityEngine;

public  class Ant : Enemy
{
    public Vector2 velocity;
    public Transform[] movePoints;
    protected override void Start()
    {
        base.Start();
        base.Intialize(20);
        DamageHit = 20;
        velocity = new Vector2(-moveSpeed, 0f);
    }
    public override void Behavior()
    {
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        if (velocity.x < 0 && rb.position.x <= movePoints[0].position.x)
        {
            Flip();
        }
        if (velocity.x > 0 && rb.position.x >= movePoints[1].position.x)
        {
            Flip();
        }
    }
    private void Flip()
    {
        velocity.x *= -1;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
