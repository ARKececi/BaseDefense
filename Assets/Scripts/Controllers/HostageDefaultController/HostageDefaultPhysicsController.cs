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
        [SerializeField] private HostageDefaultController hostageDefaultController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                hostageAIController.PlayerTarget();
                hostageDefaultController.Trigger();
            }
        }

        private void OnTriggerExit(Collider other)
        {

        }
    }
}