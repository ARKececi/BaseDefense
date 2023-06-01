using System;
using System.Collections.Generic;
using Signals;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Controllers.HostageController
{
    public class HostageMinnerAIController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public NavMeshAgent agent;
        public List<GameObject> _coalTargetList;
        public GameObject _target;

        #endregion

        #region Serialized Variables
        
        [FormerlySerializedAs("hostageAnimationController")] [SerializeField] private HostageMinnerAnimationController hostageMinnerAnimationController;

        #endregion

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
            
            MiningTarget();
        }

        public void Target(GameObject Target)
        {
            _target = Target;
        }

        public void MiningTarget()
        {
            int rand = Random.Range(0, _coalTargetList.Count - 1);
            Target(_coalTargetList[rand]);
        }

        public void BasketTarget()
        {
            Target(_coalTargetList[4]);
        }

        private void Update()
        {
            agent.destination = _target.transform.position;
        }

        private void Reset()
        {
            MiningTarget();
        }
    }
}