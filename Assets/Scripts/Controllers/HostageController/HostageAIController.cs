using System;
using System.Collections.Generic;
using Signals;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Controllers.HostageController
{
    public class HostageAIController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public NavMeshAgent agent;
        public List<GameObject> _coalTargetList;
        public GameObject _target;

        #endregion

        #region Serialized Variables
        
        [SerializeField] private HostageAnimationController hostageAnimationController;

        #endregion
        
        private bool _playerTrigger;
        private bool _miningTrigger;

        #endregion

        private void Awake()
        {
            _coalTargetList = MiningDistricSignalable.Instance.onCoalsList?.Invoke();
        }

        public void GetAgentSpeed(int Speed)
        {
            agent.speed = Speed;
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
                hostageAnimationController.Walking();
            }
        }

        public void MiningTarget()
        {
            if (_playerTrigger && _miningTrigger == false)
            {
                _miningTrigger = true;
                int rand = Random.Range(0, _coalTargetList.Count - 1);
                Target(_coalTargetList[rand]);
            }
        }

        public void TargetMe()
        {
            _target = transform.gameObject;
        }
        
        private void Update()
        {
            agent.destination = _target.transform.position;
        }

        private void Reset()
        {
            _playerTrigger = false;
            _miningTrigger = false;
        }
    }
}