using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour
{
    private Transform Target { get; set; }
    private Vector2 LastKnownTargetLocation { get; set; }

    private float Damage { get; set; }

    [Inject]
    public void Construct(Vector2 spawnLocation, Transform target, float damage)
    {
        transform.position = spawnLocation;
        Target = target;
        LastKnownTargetLocation = Target.position;
        Damage = damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        FaceTarget(LastKnownTargetLocation);
    }

    private void Update()
    {
        UpdateTargetPosition();
        FaceTarget(LastKnownTargetLocation);

        float step = 5f * Time.deltaTime;
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
            if (collision.TryGetComponent<Enemy>(out Enemy enemy))
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
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public class Factory : PlaceholderFactory<Vector2, Transform, float, Projectile> { }
}
