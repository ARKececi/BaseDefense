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

        private HostageBaseState _currentState;
        private HostageBaseState _hostageAnimationWalkingState;
        private HostageBaseState _hostageAnimationDigState;
        private HostageBaseState _hostageAnimationIdleState;
        private HostageBaseState _hostageAnimationHoldState;
        private HostageBaseState _hostageAnimationHandWState;

        #endregion

        #endregion

        private void Awake()
        {
            _hostageAnimationWalkingState = new HostageAnimationWalkingState();
            _hostageAnimationDigState = new HostageAnimationDigState();
            _hostageAnimationIdleState = new HostageAnimationIdleState();
            _hostageAnimationHoldState = new HostageAnimationHoldState();
            _hostageAnimationHandWState = new HostageAnimationHandWState();
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
            _currentState = _hostageAnimationWalkingState;
            _currentState.EnterState(this);
        }
        
        public void Dig()
        {
            _currentState = _hostageAnimationDigState;
            _currentState.EnterState(this);
        }

        public void Idle()
        {
            _currentState = _hostageAnimationIdleState;
            _currentState.EnterState(this);
        }

        public void Hold()
        {
            _currentState = _hostageAnimationHoldState;
            _currentState.EnterState(this);
        }

        public void HandW()
        {
            _currentState = _hostageAnimationHandWState;
            _currentState.EnterState(this);
        }
    }
}