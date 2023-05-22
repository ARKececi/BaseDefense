using System;
using System.Collections.Generic;
using Signals;
using UnityEngine;
using UnityEngine.AI;

namespace Controllers.HostageController
{
    public class HostageAIController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private NavMeshAgent agent;

        #endregion

        private List<GameObject> _coalTargetList;
        private GameObject _target;
        private Transform _player;

        #endregion

        private void Awake()
        {
            _player = EnemySignals.Instance.onEnemyTarget?.Invoke();
        }

        private void Start()
        {
            _target = transform.gameObject;
        }

        public void Target()
        {
            if (PlayerSignals.Instance.onLastHostage?.Invoke() == null)
            {
                _target = _player.gameObject;
            }
            else
            {
                _target = PlayerSignals.Instance.onLastHostage?.Invoke();
            }
            
        }

        private void Update()
        {
            agent.destination = _target.transform.position;
        }
    }
}