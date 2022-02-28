using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
    public Transform Target { get; set; }
    public Vector2 LastKnownTargetLocation { get; set; }
    public float Damage { get; set; }
    public float Speed { get; set; }

    [Inject]
    public void Construct()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        UpdateTargetPosition();
        FaceTarget(LastKnownTargetLocation);
    }

    private void Update()
    {
        UpdateTargetPosition();
        FaceTarget(LastKnownTargetLocation);

        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, LastKnownTargetLocation, step);

        DestroyOnCloseEnoughToTarget();
    }

    private void UpdateTargetPosition()
    {
        if (Target != null)
        {
            LastKnownTargetLocation = Target.position;
        }
    }

    private void DestroyOnCloseEnoughToTarget()
    {
        if (Vector2.Distance(transform.position, LastKnownTargetLocation) < 0.1f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            if (collision.TryGetComponent<EnemyUnit>(out EnemyUnit enemy))
            {
                enemy.TakeDamage(Damage);
            }
            
            Destroy(this.gameObject);
        }
    }

    private void FaceTarget(Vector2 targetPosition)
    {
        Vector3 targ = targetPosition;
        targ.z = 0f;

        Vector3 objectPos = transform.position;
        targ.x -= objectPos.x;
        targ.y -= objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public class Factory : PlaceholderFactory<Projectile> { }
}
