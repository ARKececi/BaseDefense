using Controllers;
using Controllers.EnemyController;
using Extentions;
using Managers;
using UnityEngine;

namespace States.PlayerStates
{
    public class EnemyAnimationRunState : EnemyAnimationBaseState
    {
        public override void EnterState(EnemyAnimationController enemyState)
        {
            enemyState.GetAnimator().SetBool("Walking", false);
            enemyState.GetAnimator().SetBool("Fight", false);
            enemyState.GetAnimator().SetBool("Idle", false);
            enemyState.GetAnimator().SetBool("Run", true);
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