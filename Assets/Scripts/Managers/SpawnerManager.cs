using System;
using System.Collections.Generic;
using Enums;
using Signalable;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class SpawnerManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public float Time = 0.05f;

        #endregion

        #region Serialized Variables

        [SerializeField] private List<GameObject> wall;
        [SerializeField] private GameObject enemySpawnDot;
        [SerializeField] private GameObject hostageSpawnDot;

        #endregion

        #region Private Variables
        
        private GameObject _boos;
        private float _enemyTimer;
        private float _hostageTimer;
        private int _enemyStackCount;
        private int _hostageStackCount;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            EnemySignals.Instance.onWall += OnWall;
            EnemySignals.Instance.onStackRemove += EnemyStackRemove;
        }

        private void UnsubscribeEvents()
        {
            EnemySignals.Instance.onWall -= OnWall;
            EnemySignals.Instance.onStackRemove -= EnemyStackRemove;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion
        
        private void Awake()
        {
            _enemyStackCount = 0;
        }

        private void Update()
        {
            EnemyTimer();
            HostageTimer();
        }
        
        public List<GameObject> OnWall()
        {
            return wall;
        }

        #region EnemySpawn
        
        public void EnemyStackRemove()
        {
            _enemyStackCount--;
        }
            
        private void EnemySpawner(GameObject Enemy)
        {
            int enemyPositionX = Random.Range(-10, 10);
            GameObject enemy = Enemy;
            var position = enemySpawnDot.transform.position;
            enemy.transform.position = new Vector3(enemyPositionX, position.y, position.z);
        }

        private void EnemyTimer()
        {
            if (_enemyStackCount < 9)
            {
                while(_enemyTimer < 0)
                {
                    EnemySpawner(PoolSignalable.Instance.onListRemove?.Invoke(PoolType.EnemyEasy));
                    _enemyStackCount++;
                    _enemyTimer = Time;
                } 
                _enemyTimer -= UnityEngine.Time.deltaTime;
            }
        }
            
        #endregion

        #region Hostage Spawn

        public void HostageStackRemove()
        {
            _hostageStackCount--;
        }
            
        private void HostageSpawner(GameObject Hostage)
        {
            int HostagePositionX = Random.Range(-10, 10);
            int HostagePositionZ = Random.Range(-3, 3);
            GameObject hostage = Hostage;
            var position = hostageSpawnDot.transform.position;
            hostage.transform.position = new Vector3(HostagePositionX, position.y, position.z + HostagePositionZ);
        }

        private void HostageTimer()
        {
            if (_hostageStackCount < 9)
            {
                while(_hostageTimer < 0)
                {
                    HostageSpawner(PoolSignalable.Instance.onListRemove?.Invoke(PoolType.HostageDefault));
                    _hostageStackCount++;
                    _hostageTimer = Time;
                }
                _hostageTimer -= UnityEngine.Time.deltaTime;
            }
        }

        #endregion

    }
}