using System;
using Extentions;
using HostageStates;
using UnityEngine;

namespace Controllers.HostageController
{
    public class HostageMinnerAnimationController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Animator animator;

        #endregion

        #region Private Variables

        private HostageMinerBaseState _currentState;
        private HostageMinerBaseState _hostageMinerAnimationWalkingState;
        private HostageMinerBaseState _hostageMinerAnimationDigState;
        private HostageMinerBaseState _hostageMinerAnimationIdleState;
        private HostageMinerBaseState _hostageMinerAnimationHoldState;
        private HostageMinerBaseState _hostageMinerAnimationHandWState;
        private HostageMinerBaseState _hostageMinerAnimationHandIState;

        #endregion

        #endregion

        private void Awake()
        {
            _hostageMinerAnimationWalkingState = new HostageMinerAnimationWalkingState();
            _hostageMinerAnimationDigState = new HostageMinerAnimationDigState();
            _hostageMinerAnimationIdleState = new HostageMinerAnimationIdleState();
            _hostageMinerAnimationHoldState = new HostageMinerAnimationHoldState();
            _hostageMinerAnimationHandWState = new HostageMinerAnimationHandWState();
            _hostageMinerAnimationHandIState = new HostageMinerAnimationHandIState();
        }

        public Animator GetAnimator()
        {
            return animator;
        }

        private void Start()
        {
            Walking();
            HandW();
        }

        public void Walking()
        {
            _currentState = _hostageMinerAnimationWalkingState;
            _currentState.EnterState(this);
        }
        
        public void Dig()
        {
            _currentState = _hostageMinerAnimationDigState;
            _currentState.EnterState(this);
        }

        public void Idle()
        {
            _currentState = _hostageMinerAnimationIdleState;
            _currentState.EnterState(this);
        }

        public void Hold()
        {
            _currentState = _hostageMinerAnimationHoldState;
            _currentState.EnterState(this);
        }

        public void HandW()
        {
            _currentState = _hostageMinerAnimationHandWState;
            _currentState.EnterState(this);
        }

        public void HandI()
        {
            _currentState = _hostageMinerAnimationHandIState;
            _currentState.EnterState(this);
        }
    }
}