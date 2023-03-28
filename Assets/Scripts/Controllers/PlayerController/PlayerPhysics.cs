using System;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class PlayerPhysics : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private PlayerAnimatorController playerAnimatorController;

        #endregion

        #endregion

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("SafeHouse"))
            {
                playerAnimatorController.SafeHouse();
                PlayerSignals.Instance.onTargetWall?.Invoke();
            }
        }
    }
}