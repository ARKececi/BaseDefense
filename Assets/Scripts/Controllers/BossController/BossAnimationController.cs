using System;
using Extentions;
using States.PlayerStates;
using UnityEngine;

namespace Controllers.BossController
{
    public class BossAnimationController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Animator animator;

        #endregion

        #region Private Variables

        private BossBaseState _currentState;
        private BossBaseState _bossIdleState;
        private BossBaseState _bossFighState;
        private BossBaseState _bossDeadState;

        #endregion

        #endregion

        private void Awake()
        {
            _bossIdleState = new BossIdleState();
            _bossFighState = new BossFightState();
            _bossDeadState = new BossDeadState();
        }

        private void Start()
        {
            Idle();
        }
        
        public Animator GetAnimator()
        {
            return animator;
        }

        public void Idle()
        {
            _currentState = _bossIdleState;
            _currentState.EnterState(this);
        }

        public void Fight()
        {
            _currentState = _bossFighState;
            _currentState.EnterState(this);
        }

        public void Dead()
        {
            _currentState = _bossDeadState;
            _currentState.EnterState(this);
        }
    }
}