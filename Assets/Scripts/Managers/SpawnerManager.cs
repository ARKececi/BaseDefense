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
        public List<GameObject> DeadEnemy;

        #endregion

        #region Serialized Variables

        [SerializeField] private List<GameObject> wall;
        [SerializeField] private GameObject enemySpawnDot;

        #endregion

        #region Private Variables
        
        private GameObject _boos;
        private float _timer;
        private int _stackCount;

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
            EnemySignals.Instance.onStackRemove += StackRemove;
        }

        private void UnsubscribeEvents()
        {
            EnemySignals.Instance.onWall -= OnWall;
            EnemySignals.Instance.onStackRemove -= StackRemove;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        #region EnemySpawn
        
            private void Awake()
            {
                _stackCount = 0;
            }

            private void Update()
            {
                Timer();
            }

            public void StackRemove()
            {
                _stackCount--;
            }
            
            private void Spawner(GameObject Enemy)
            {
                int enemyPositionX = Random.Range(-10, 10);
                GameObject enemy = Enemy;
                var position = enemySpawnDot.transform.position;
                enemy.transform.position = new Vector3(enemyPositionX, position.y,
                    position.z);
            }

            private void Timer()
            {
                if (_stackCount < 9)
                {
                    while(_timer < 0)
                    {
                        Spawner(PoolSignalable.Instance.onListRemove?.Invoke(PoolType.EnemyEasy));
                        _stackCount++;
                        _timer = Time;
                    }
                    _timer -= UnityEngine.Time.deltaTime;
                }
            }

            public List<GameObject> OnWall()
            {
                return wall;
            }
            
        #endregion

    }
}