using System;
using UnityEngine;

namespace Controllers.HostageController
{
    public class HostagePhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
        
        [SerializeField] private HostageAIController hostageAIController;
        [SerializeField] private HostageController hostageController;
        [SerializeField] private HostageAnimationController hostageAnimationController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                hostageAIController.PlayerTarget();
            }

            if (other.CompareTag("Coal"))
            {
                hostageController.Dig(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {

        }
    }
}