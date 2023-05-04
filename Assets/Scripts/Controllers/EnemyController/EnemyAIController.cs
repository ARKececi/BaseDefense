using System;
using System.Collections.Generic;
using Signals;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

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

        #endregion
        
        #endregion

        private void Start()
        {
            _wall = EnemySignals.Instance.onWall?.Invoke();
            TargetWall();
        }

        public void TargetWall()
        {
            if (transform.position.x < 0) target = _wall[0].transform;
            else target = _wall[1].transform;
        }

        public void OnTaretPlayer()
        {
            target = EnemySignals.Instance.onEnemyTarget?.Invoke();
        }

        private void Update()
        {
            _agent.destination = target.position;
        }
    }
}