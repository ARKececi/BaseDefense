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
        [SerializeField] private GameObject _home;

        #endregion

        #region Private Variables
        
        private GameObject _boos;
        private float _enemyTimer;
        private float _hostageTimer;
        private int _enemyStackCount;
        private int _hostageDefaultStackCount;
        private int _hostageStackMinerCount;

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
            PlayerSignals.Instance.hostageMinerSpawn += HostageMinerSpawn;
            HostageDefaultSignalable.Instance.hostageStackRemove += HostageStackRemove;
            HostagePickerSignalable.Instance.onHome += OnHome;
        }

        private void UnsubscribeEvents()
        {
            EnemySignals.Instance.onWall -= OnWall;
            EnemySignals.Instance.onStackRemove -= EnemyStackRemove;
            PlayerSignals.Instance.hostageMinerSpawn -= HostageMinerSpawn;
            HostageDefaultSignalable.Instance.hostageStackRemove -= HostageStackRemove;
            HostagePickerSignalable.Instance.onHome -= OnHome;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void Update()
        {
            EnemyTimer();
            HostageTimer();
        }
        
        public List<GameObject> OnWall()
        {
            return wall;
        }

        public GameObject OnHome()
        {
            return _home;
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

        #region Hostage Default Spawn

        public void HostageStackRemove()
        {
            _hostageDefaultStackCount--;
        }
            
        private void HostageSpawner(GameObject Hostage)
        {
            if (Hostage != null)
            {
                int HostagePositionX = Random.Range(-10, 10);
                int HostagePositionZ = Random.Range(-3, 7);
                GameObject hostage = Hostage;
                var position = hostageSpawnDot.transform.position;
                hostage.transform.position = new Vector3(HostagePositionX, position.y, position.z + HostagePositionZ);
            }
            else
            {
                _hostageDefaultStackCount--;
            }
        }

        private void HostageTimer()
        {
            if (_hostageDefaultStackCount < 3)
            {
                while(_hostageTimer < 0)
                {
                    HostageSpawner(PoolSignalable.Instance.onListRemove?.Invoke(PoolType.HostageDefault));
                    _hostageDefaultStackCount++;
                    _hostageTimer = Time;
                }
                _hostageTimer -= UnityEngine.Time.deltaTime;
            }
        }

        #endregion

        #region Hostage Miner Spawn

        public void HostageMinerSpawn(GameObject hostage)
        {
            if (_hostageStackMinerCount < 11)
            {
                var position = hostage.transform.position;
                HostageDefaultSignalable.Instance.Reset?.Invoke(hostage);
                PoolSignalable.Instance.onListAdd?.Invoke(hostage,PoolType.HostageDefault);
                var miner = PoolSignalable.Instance.onListRemove?.Invoke(PoolType.HostageMinner);
                if (miner != null)
                {
                    miner.transform.position = position;
                }
                _hostageStackMinerCount++;
                if (_hostageStackMinerCount == 11)
                {
                    SpawnerSignals.Instance.onFullMiner?.Invoke(true);
                }
            }
        }
        #endregion

        #region Hostage Picker Spawn

        public void HostagePickerSpawn(Transform transform)
        {
            GameObject picker = PoolSignalable.Instance.onListRemove?.Invoke(PoolType.HostagePicker);
            picker.transform.position = transform.position;
        }

        #endregion
    }
}