using Controllers;
using Controllers.EnemyController;
using Extentions;
using Managers;
using UnityEngine;

namespace States.PlayerStates
{
    public class EnemyAnimationWalkingState : EnemyAnimationBaseState
    {
        public override void EnterState(EnemyAnimationController enemyState)
        {
            enemyState.GetAnimator().SetBool("Walking", true);
            enemyState.GetAnimator().SetBool("Fight", false);
            enemyState.GetAnimator().SetBool("Idle", false);
            enemyState.GetAnimator().SetBool("Run", false);
            enemyState.GetAnimator().SetBool("Dead", false);
        }

        public override void UpdateState(EnemyAnimationController enemyState)
        {
            
        }
        
        public override void OnCollisionEnter(EnemyAnimationController enemyState)
        {
            
        }
    }
}