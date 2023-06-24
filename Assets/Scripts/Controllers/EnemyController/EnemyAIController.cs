using System;
using System.Collections.Generic;
using Enums;
using Signals;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Controllers.EnemyController
{
    public class EnemyAIController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables
        
        public NavMeshAgent _agent;
        
        #endregion

        #region Serialized Variables

        [SerializeField] private Transform target;
        [SerializeField] private EnemyAnimationController enemyAnimationController;

        #endregion

        #region Private Variables

        private List<GameObject> _wall;
        private bool _safeHouse;
        private int _normalSpeed;
        private int _fastSpeed;

        #endregion
        
        #endregion

        private void Start()
        {
            _wall = EnemySignals.Instance.onWall?.Invoke();
            TargetWall();
        }

        public bool ReSafeHouse()
        {
            return _safeHouse;
        }

        public void FirstSafeHouse()
        {
            _safeHouse = (bool)EnemySignals.Instance.onReturnSafeHouse?.Invoke();
        }

        public void OnSpeed(int NormalSpeed, int FastSpeed)
        {
            _normalSpeed = NormalSpeed;
            _fastSpeed = FastSpeed;
        }

        public void SafeHouse(bool safehouse)
        {
            _safeHouse = safehouse;
        }

        public void TargetWall()
        {
            if (_wall.Contains(target.gameObject) == false)
            {
                int count = Random.Range(0, _wall.Count);
                target = _wall[count].transform;
                _agent.speed = _normalSpeed;
                enemyAnimationController.Walking();
            }
        }

        public void OnTaretPlayer()
        {
            if (_safeHouse == false)
            {
                target = EnemySignals.Instance.onEnemyTarget?.Invoke();
                _agent.speed = _fastSpeed;
                enemyAnimationController.Run();
            }
        }

        public void OnNullTarget()
        {
            target = transform;
        }

        private void Update()
        {
            _agent.destination = target.position;
        }
    }
}