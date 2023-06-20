using System;
using Extentions;
using HostageStates;
using UnityEngine;

namespace Controllers.HostageDefaultController
{
    public class HostageDefaultAnimationController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Animator animator;

        #endregion

        #region Private Variables

        private HostageDefaultBaseState _currentState;
        private HostageDefaultBaseState _hostageDefaultAnimationWalkingState;
        private HostageDefaultBaseState _hostageDefaultAnimationIdleState;
        private HostageDefaultBaseState _hostageDefaultAnimationHostageState;

        #endregion

        #endregion
        
        public Animator GetAnimator()
        {
            return animator;
        }

        private void Awake()
        {
            _hostageDefaultAnimationWalkingState = new HostageDefaultAnimationWalkingState();
            _hostageDefaultAnimationIdleState = new HostageDefaultAnimationIdleState();
            _hostageDefaultAnimationHostageState = new HostageDefaultAnimationHostageState();
        }

        public void Idle()
        {
            _currentState = _hostageDefaultAnimationIdleState;
            _currentState.EnterState(this);
        }
        
        public void Walking()
        {
            _currentState = _hostageDefaultAnimationWalkingState;
            _currentState.EnterState(this);
        }
        
        public void Hostage()
        {
            _currentState = _hostageDefaultAnimationHostageState;
            _currentState.EnterState(this);
        }

        public void Reset()
        {
            Hostage();
        }
    }
}