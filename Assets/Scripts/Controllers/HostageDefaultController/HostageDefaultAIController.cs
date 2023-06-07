using System;
using System.Collections.Generic;
using Controllers.HostageDefaultController;
using Signals;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Controllers.HostageController
{
    public class HostageDefaultAIController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        
        public GameObject _target;

        #endregion

        #region Serialized Variables
        
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private HostageDefaultAnimationController hostageDefaultAnimationController;

        #endregion
        
        private bool _playerTrigger;
        private bool _miningTrigger;

        #endregion

        public void GetAgentSpeed(float Speed)
        {
            navMeshAgent.speed = Speed;
        }

        private void Start()
        {
            _target = transform.gameObject;
        }

        public void Target(GameObject Target)
        {
            _target = Target;
        }

        public void PlayerTarget()
        {
            if (_playerTrigger == false)
            {
                Target( PlayerSignals.Instance.onLastHostage?.Invoke(transform.gameObject));
                _playerTrigger = true;
            }
        }

        public void TargetMe()
        {
            _target = transform.gameObject;
        }

        private void Update()
        {
            navMeshAgent.destination = _target.transform.position;
        }

        public void Reset()
        {
            _playerTrigger = false;
            _miningTrigger = false;
            _target = transform.gameObject;
        }
    }
}