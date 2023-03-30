using System;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerAnimatorController playerAnimatorController;
        [SerializeField] private StackController stackController;

        #endregion

        #endregion

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Money"))
            {
                stackController.AddMoney(other.gameObject);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("SafeHouse"))
            {
                playerAnimatorController.SafeHouse();
                PlayerSignals.Instance.onTargetWall?.Invoke();
                PlayerSignals.Instance.onSafeHouse?.Invoke();
            }
        }
    }
}