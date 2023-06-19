using System;
using Extentions;
using States.AnimationStates.HostagePickerState;
using UnityEngine;

namespace Controllers.HostagePickerController
{
    public class HostagePickerAnimationController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Animator animator;

        #endregion

        #region Private Variables

        private HostagePickerBaseState _currentState;
        private HostagePickerBaseState _hostagePickerIdleState;
        private HostagePickerBaseState _hostagePickerWalkingState;

        #endregion

        #endregion

        private void Awake()
        {
            _hostagePickerIdleState = new HostagePickerAnimationIdleState();
            _hostagePickerWalkingState = new HostagePickerAnimationWalkingState();
        }

        public Animator GetAnimator()
        {
            return animator;
        }

        public void Idle()
        {
            _currentState = _hostagePickerIdleState;
            _currentState.EnterState(this);
        }
        
        public void Walking()
        {
            _currentState = _hostagePickerWalkingState;
            _currentState.EnterState(this);
        }
    }
}