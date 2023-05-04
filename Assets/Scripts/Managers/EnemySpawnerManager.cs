using System;
using System.Collections.Generic;
using Signals;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class EnemySpawnerManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public float Time = 0.05f;
        public List<GameObject> EnemyPool;
        public List<GameObject> DeadEnemy;
        public List<EnemyController.EnemyController> EnemyControllers;

        #endregion

        #region Serialized Variables

        [SerializeField] private List<GameObject> wall;
        [SerializeField] private List<GameObject> enemyList;
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
            EnemySignals.Instance.onDeadEnemy += DeadEnemyObj;
        }

        private void UnsubscribeEvents()
        {
            EnemySignals.Instance.onWall -= OnWall;
            EnemySignals.Instance.onDeadEnemy += DeadEnemyObj;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void Awake()
        {
            PoolLoading();
            _stackCount = 0;
        }

        private void Update()
        {
            Timer();
        }

        private void Listadd()
        {
            GameObject enemy = Instantiate(enemyList[0]);
            var EnemyController = enemy.GetComponent<EnemyController.EnemyController>();
            EnemyControllers.Add(EnemyController);
            EnemyPool.Add(enemy);
            EnemyControllers[_stackCount].Active(false);
            _stackCount++;
        }

        private void PoolLoading()
        {
            for (int i = 0; i < 10; i++)
            {
                Listadd();
            }
            _stackCount = 0;
        }

        private void Spawner(GameObject Enemy)
        {
            int enemyPositionX = Random.Range(-10, 10);
            GameObject enemy = Enemy;
            var position = enemySpawnDot.transform.position;
            enemy.transform.position = new Vector3(enemyPositionX, position.y,
                position.z);
            EnemyControllers[EnemyPool.IndexOf(Enemy)].Active(true);
        }

        private void Timer()
        {
            if (_stackCount < 9)
            {
                while(_timer < 0)
                {
                    Spawner(EnemyPool[_stackCount]);
                    _stackCount++;
                    _timer = Time;
                }
                _timer -= UnityEngine.Time.deltaTime;
            }
            else if (DeadEnemy.Count > 0)
            {
                while (_timer < 0)
                {
                    Spawner(DeadEnemy[0]);
                    DeadEnemy.Remove(DeadEnemy[0]);
                    _timer = Time;
                }
                _timer -= UnityEngine.Time.deltaTime;
            }
        }
        
        public void DeadEnemyObj(GameObject deadEnemy)
        {
            EnemyControllers[EnemyPool.IndexOf(deadEnemy)].Active(false);
            DeadEnemy.Add(deadEnemy);
        }

        public void SafeHouse()
        {

        }

        public List<GameObject> OnWall()
        {
            return wall;
        }
    }
}