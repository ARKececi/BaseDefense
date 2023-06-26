using System;
using Extentions;
using States.AnimationStates.HostagePickerState;
using States.AnimationStates.TransporterManStates;
using UnityEngine;

namespace Controllers.TransporterManController
{
    public class TransporterManAnimationController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Animator animator;

        #endregion

        #region Private Variables

        private TransporterManBaseState _currentState;
        private TransporterManBaseState _transporterManIdleState;
        private TransporterManBaseState _transporterManWalkingState;

        #endregion

        #endregion

        private void Awake()
        {
            _transporterManIdleState = new TransporterManAnimationIdleState();
            _transporterManWalkingState = new TransporterManAnimationWalkingState();
        }

        private void Start()
        {
            Walking();
        }

        public Animator GetAnimator()
        {
            return animator;
        }
        
        public void Idle()
        {
            _currentState = _transporterManIdleState;
            _currentState.EnterState(this);
        }
        
        public void Walking()
        {
            _currentState = _transporterManWalkingState;
            _currentState.EnterState(this);
        }
    }
}