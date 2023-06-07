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
        private Vector3 worldPosition;

        #endregion

        #endregion


        public void Trigger()
        {
            _playerTrigger = true;
        }
        
        private void FixedUpdate()
        {
            if (_playerTrigger)
            {
                if (rigidbody.worldCenterOfMass == worldPosition)
                {
                    hostageDefaultAnimationController.Idle();
                }
                else
                {
                    hostageDefaultAnimationController.Walking();
                }
                worldPosition = rigidbody.worldCenterOfMass;
            }
        }

        public void Reset()
        {
            _playerTrigger = false;
        }
    }
}