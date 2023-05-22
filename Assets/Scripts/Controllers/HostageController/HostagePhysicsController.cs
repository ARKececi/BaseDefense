using System;
using UnityEngine;

namespace Controllers.HostageController
{
    public class HostagePhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private HostageAnimationController hostageAnimationController;
        [SerializeField] private HostageAIController hostageAIController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                hostageAIController.Target();
                hostageAnimationController.Walking();
            }
        }
    }
}