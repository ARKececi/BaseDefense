using System;
using Extentions;
using HostageStates;
using UnityEngine;

namespace Controllers.HostageController
{
    public class HostageAnimationController : MonoBehaviour
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
        private HostageBaseState _hostageAnimationHostageState;

        #endregion

        #endregion

        private void Awake()
        {
            _hostageAnimationWalkingState = new HostageAnimationWalkingState();
            _hostageAnimationDigState = new HostageAnimationDigState();
            _hostageAnimationIdleState = new HostageAnimationIdleState();
            _hostageAnimationHoldState = new HostageAnimationHoldState();
            _hostageAnimationHostageState = new HostageAnimationHostageState();
            
            Hostage();
        }
        
        public Animator GetAnimator()
        {
            return animator;
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
        
        public void Hostage()
        {
            _currentState = _hostageAnimationHostageState;
            _currentState.EnterState(this);
        }
    }
}