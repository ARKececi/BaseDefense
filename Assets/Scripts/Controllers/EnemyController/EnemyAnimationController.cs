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

        private EnemyBaseState _currentState;
        private EnemyBaseState _enemyWalkingState;
        private EnemyBaseState _enemyFightState;

        #endregion

        #endregion

        private void Awake()
        {
            _enemyWalkingState = new EnemyWalkingState();
            _enemyFightState = new EnemyFightState();
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
            _currentState = _enemyWalkingState;
            _currentState.EnterState(this);
        }

        public void Fight()
        {
            _currentState = _enemyFightState;
            _currentState.EnterState(this);
        }
    }
}