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

        public void OnSpeed(int NormalSpeed, int FastSpeed)
        {
            _normalSpeed = NormalSpeed;
            _fastSpeed = FastSpeed;
        }

        public void TargetWall()
        {
            int count = Random.Range(0, _wall.Count);
            target = _wall[count].transform;
            //if (transform.position.x < 0) target = _wall[0].transform;else target = _wall[1].transform;
            _agent.speed = _normalSpeed;
        }

        public void OnTaretPlayer()
        {
            target = EnemySignals.Instance.onEnemyTarget?.Invoke();
            _agent.speed = _fastSpeed;
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