using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    private Transform Target { get; set; }
    private Vector2 LastKnownTargetLocation { get; set; }

    private float Damage { get; set; }
    private float Speed { get; set; }
    private Sprite Sprite { get; set; }

    [Inject]
    public void Construct(Vector2 spawnLocation, Transform target, Sprite sprite, float damage, float speed)
    {
        transform.position = spawnLocation;
        Target = target;
        LastKnownTargetLocation = Target.position;
        Damage = damage;
        Speed = speed;
        Sprite = sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
        FaceTarget(LastKnownTargetLocation);
        _spriteRenderer.sprite = Sprite;
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

    public class Factory : PlaceholderFactory<Vector2, Transform, Sprite, float, float, Projectile> { }
}
