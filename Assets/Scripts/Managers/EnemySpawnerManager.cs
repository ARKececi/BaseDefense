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
        public List<GameObject> enemyPool;
        public List<GameObject> activeEnemy;

        #endregion

        #region Serialized Variables

        [SerializeField] private List<GameObject> wall;
        [SerializeField] private List<GameObject> enemyList;
        [SerializeField] private GameObject enemySpawnDot;

        #endregion

        #region Private Variables
        
        private GameObject _boos;
        private float _timer;

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
        }

        private void UnsubscribeEvents()
        {
            EnemySignals.Instance.onWall -= OnWall;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        private void Awake()
        {
            PoolLoading();
        }

        private void Update()
        {
            Timer();
        }

        private void Listadd()
        {
            GameObject enemy = Instantiate(enemyList[0]);
            enemyPool.Add(enemy);
            enemy.SetActive(false);
        }

        private void PoolLoading()
        {
            for (int i = 0; i < 10; i++)
            {
                Listadd();
            }
        }

        private void Spawner()
        {
            int enemyPositionX = Random.Range(-10, 10);
            GameObject enemy = enemyPool[0];
            activeEnemy.Add(enemy);
            enemyPool.Remove(enemy);
            var position = enemySpawnDot.transform.position;
            enemy.transform.position = new Vector3(enemyPositionX, position.y,
                position.z);
            enemy.SetActive(true);
        }
        
        private void Timer()
        {
            if (enemyPool.Count != 0)
            {
                while(_timer < 0)
                {
                    Spawner();
                    _timer = Time;
                }
                _timer -= UnityEngine.Time.deltaTime;
            }
        }

        public List<GameObject> OnWall()
        {
            return wall;
        }
    }
}