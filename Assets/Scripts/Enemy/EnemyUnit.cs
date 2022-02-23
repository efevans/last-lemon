using System.Linq;
using UnityEngine;
using Zenject;

public class EnemyUnit : MonoBehaviour
{
    private SignalBus _signalBus;
    private Waypoint _waypoint;
    private Transform _target;
    private int _waypointIndex;

    private float _speed;
    private float _health;

    private Enemy _enemy;

    [SerializeField]
    private ProgressBar _progressBar;
    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    [Inject]
    public void Construct(SignalBus signalBus, Enemy enemy, Vector2 spawnLocation, Waypoint waypoint)
    {
        _signalBus = signalBus;
        _enemy = enemy;
        transform.position = spawnLocation;
        _waypoint = waypoint;
    }

    private void Start()
    {
        _waypointIndex = 0;
        _target = _waypoint.Waypoints.ElementAt(0);
        _speed = _enemy.Speed;
        _health = _enemy.Health;
        _spriteRenderer.sprite = _enemy.Sprite;
        _progressBar.SetMax(_health);
        _progressBar.UpdateAmount(_health);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(_target.position, transform.position) < 10f)
        {
            MoveToNextWaypoint();
        }
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;
        _health = Mathf.Max(_health, 0);
        _progressBar.UpdateAmount(_health);

        if (_health <= 0)
        {
            OnDeath();
            Destroy(gameObject);
        }
    }

    public void OnDeath()
    {
        _signalBus.AbstractFire<SignalEnemyDeath>();
    }

    private void MoveToNextWaypoint()
    {
        _waypointIndex++;
        _target = _waypoint.Waypoints.ElementAt(_waypointIndex);
    }

    public class Factory : PlaceholderFactory<Enemy, Vector2, EnemyUnit> { }
}
