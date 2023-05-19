using System;
using Extentions;
using States.PlayerStates;
using UnityEngine;

namespace Controllers.EnemyController
{
    public class EnemyAnimationController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Animator animator;

        #endregion

        #region Private Variables

        private EnemyAnimationBaseState _currentState;
        private EnemyAnimationBaseState _enemyAnimationWalkingState;
        private EnemyAnimationBaseState _enemyAnimationFightState;
        private EnemyAnimationBaseState _enemyAnimationIdleState;
        private EnemyAnimationBaseState _enemyAnimationDeadState;

        #endregion

        #endregion

        private void Awake()
        {
            _enemyAnimationWalkingState = new EnemyAnimationWalkingState();
            _enemyAnimationFightState = new EnemyAnimationFightState();
            _enemyAnimationIdleState = new EnemyAnimationIdleState();
            _enemyAnimationDeadState = new EnemyAnimationDeadState();
        }

        private void Start()
        {
            Walking();
        }

        public Animator GetAnimator()
        {
            return animator;
        }

        public void Walking()
        {
            _currentState = _enemyAnimationWalkingState;
            _currentState.EnterState(this);
        }

        public void Fight()
        {
            _currentState = _enemyAnimationFightState;
            _currentState.EnterState(this);
        }

        public void Idle()
        {
            _currentState = _enemyAnimationIdleState;
            _currentState.EnterState(this);
        }

        public void Dead()
        {
            _currentState = _enemyAnimationDeadState;
            _currentState.EnterState(this);
        }
    }
}