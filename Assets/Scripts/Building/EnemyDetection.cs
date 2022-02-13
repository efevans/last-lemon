using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public LayerMask EnemyLayer;

    [SerializeField]
    public Transform TargetedEnemy { get; private set; }
    public List<Transform> EnemiesInRange { get; set; } = new List<Transform>();

    [SerializeField]
    public bool EnemyDetected { get; private set; }

    [Range(0f, 5f)]
    public float Radius;

    [Header("Gizmo Parameters")]
    public Color GizmoIdleColor;
    public Color GizmoDetectedColor;
    public bool ShowGizmos = true;

    // Update is called once per frame
    void Update()
    {
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(EnemyLayer);

        List<Collider2D> inRangeTargets = new List<Collider2D>();
        Physics2D.OverlapCircle(transform.position, Radius, filter, inRangeTargets);

        EnemiesInRange = inRangeTargets.Select(t => t.transform).ToList();
        if (inRangeTargets.Count > 0)
        {
            TargetedEnemy = inRangeTargets.First().transform;
        }
        else
        {
            TargetedEnemy = null;
        }
    }

    private void OnDrawGizmos()
    {
        if (ShowGizmos)
        {
            Gizmos.color = GizmoIdleColor;
            Gizmos.DrawSphere(transform.position, Radius);
        }
    }
}
