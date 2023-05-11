using System;
using UnityEngine;

namespace Controllers.BossController
{
    public class BossPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private BossAnimationController bossAnimationController;

        #endregion

        #endregion
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                bossAnimationController.Fight();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                bossAnimationController.Idle();
            }
        }
    }
}