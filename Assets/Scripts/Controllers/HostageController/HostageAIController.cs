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

        #region Public Variables

        public NavMeshAgent agent;

        #endregion

        #region Serialized Variables
        
        [SerializeField] private HostageAnimationController hostageAnimationController;

        #endregion

        private List<GameObject> _coalTargetList;
        private GameObject _target;
        private Transform _player;
        private bool _trigger;

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
            if (_trigger == false)
            {
                _target = PlayerSignals.Instance.onLastHostage?.Invoke(transform.gameObject);
                _trigger = true;
                hostageAnimationController.Walking();
            }
        }

        private void Update()
        {
            agent.destination = _target.transform.position;
        }

        private void Reset()
        {
            _trigger = false;
        }
    }
}