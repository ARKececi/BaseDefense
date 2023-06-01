using System;
using Controllers.HostageController;
using UnityEngine;

namespace Controllers.HostageDefaultController
{
    public class HostageDefaultPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private HostageDefaultAIController hostageAIController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                hostageAIController.PlayerTarget();
            }
        }

        private void OnTriggerExit(Collider other)
        {

        }
    }
}