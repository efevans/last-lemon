using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class Enemy : MonoBehaviour
{
    private SignalBus _signalBus;
    private Waypoint _waypoint;
    private Transform _target;
    private int _waypointIndex;

    private float _speed = 1.5f;
    private float _health = 10;

    [SerializeField]
    private ProgressBar _progressBar;

    [Inject]
    public void Construct(SignalBus signalBus, Vector2 spawnLocation, Waypoint waypoint)
    {
        _signalBus = signalBus;
        transform.position = spawnLocation;
        _waypoint = waypoint;
    }

    private void Start()
    {
        _waypointIndex = 0;
        _target = _waypoint.Waypoints.ElementAt(0);
        _progressBar.SetMax(_health);
        _progressBar.UpdateAmount(_health);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 dir = _target.position - transform.position;
        transform.Translate(dir.normalized * _speed * Time.deltaTime, Space.World);

        if (Vector2.Distance(_target.position, transform.position) < 0.2f)
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

    public class Factory : PlaceholderFactory<Vector2, Enemy> { }
}
