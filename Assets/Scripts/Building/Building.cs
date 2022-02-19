using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Building
{
    public class Building : MonoBehaviour
    {
        public Projectile.Factory ProjectileFactory { get; private set; }

        public EnemyDetection EnemyDetection;

        [HideInInspector]
        public TowerStateController TowerStateController;
        private Tower _tower;

        [Inject]
        public void Construct(Tower tower, Vector2 spawnLocation, Projectile.Factory factory)
        {
            _tower = tower;
            transform.position = spawnLocation;
            ProjectileFactory = factory;
        }

        // Start is called before the first frame update
        void Start()
        {
            _tower.TowerController.Setup(this);
        }

        // Update is called once per frame
        void Update()
        {
            this.TowerStateController.Update(this);
        }

        public void SetRange(float range)
        {
            EnemyDetection.Radius = range;
        }

        public void ApplyUpgrade(UpgradeBehavior upgrade)
        {
            this.TowerStateController.ApplyUpgrade(upgrade);
        }

        public class Factory : PlaceholderFactory<Tower, Vector2, Building> { }
    }
}