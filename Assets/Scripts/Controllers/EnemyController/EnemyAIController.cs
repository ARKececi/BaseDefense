using System;
using UnityEngine;
using UnityEngine.AI;

namespace Controllers.EnemyController
{
    public class EnemyAIController : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables

        public Transform Target;
        public NavMeshAgent _agent;
        
        #endregion

        #region Pirvate Variables

        

        #endregion

        #endregion

        private void Start()
        {
            
        }

        private void Update()
        {
            _agent.destination = Target.position;
        }
    }
}