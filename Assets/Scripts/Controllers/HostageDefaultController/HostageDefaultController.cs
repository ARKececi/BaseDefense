using System;
using UnityEngine;

namespace Controllers.HostageDefaultController
{
    public class HostageDefaultController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private HostageDefaultAnimationController hostageDefaultAnimationController;

        #endregion

        #region Private Variables

        private bool _playerTrigger;

        #endregion

        #endregion

        private void FixedUpdate()
        {
            if (_playerTrigger)
            {
                if (rigidbody.velocity == Vector3.zero)
                {
                    hostageDefaultAnimationController.Idle();
                }
                else
                {
                    hostageDefaultAnimationController.Walking();
                }
            }
        }

        private void Reset()
        {
            _playerTrigger = false;
        }
    }
}