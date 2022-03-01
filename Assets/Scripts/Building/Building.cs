using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Building
{
    public class Building : MonoBehaviour
    {
        public ProjectileBuilder.Factory ProjectileBuilderFactory { get; private set; }
        public BuildableSpot.Factory BuildableSpotFactory { get; private set; }

        public EnemyDetection EnemyDetection;
        public AudioSource AudioSource;

        private MySettings _settings;

        [HideInInspector]
        public TowerStateController TowerStateController;
        private Tower _tower;

        [Inject]
        public void Construct(
            Tower tower,
            Vector2 spawnLocation,
            BuildableSpot.Factory buildableFactory,
            ProjectileBuilder.Factory projectileBuilderFactory,
            MySettings mySettings)
        {
            _tower = tower;
            transform.position = spawnLocation;
            BuildableSpotFactory = buildableFactory;
            ProjectileBuilderFactory = projectileBuilderFactory;
            _settings = mySettings;
        }

        // Start is called before the first frame update
        void Awake()
        {
            AudioSource.PlayOneShot(_settings.OnBuildSE, _settings.Volume);
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

        public void Unbuild()
        {
            BuildableSpotFactory.Create(transform.position);
            Destroy(gameObject);
        }

        public class Factory : PlaceholderFactory<Tower, Vector2, Building> { }

        [Serializable]
        public class MySettings
        {
            public AudioClip OnBuildSE;
            [Range(0, 1)]
            public float Volume;
        }
    }
}