using System;
using Controllers.HostageController;
using Unity.VisualScripting;
using UnityEngine;

namespace Controllers.HostageDefaultController
{
    public class HostageDefaultPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private HostageDefaultAIController hostageAIController;
        [SerializeField] private HostageDefaultController hostageDefaultController;
        [SerializeField] private HostageDefaultAnimationController hostageDefaultAnimationController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                hostageAIController.PlayerTarget();
                hostageDefaultController.Trigger();
                hostageDefaultController.Decrease();
            }
        }

        private void OnTriggerExit(Collider other)
        {

        }
    }
}