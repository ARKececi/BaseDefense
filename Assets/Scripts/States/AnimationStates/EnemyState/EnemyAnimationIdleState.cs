using Controllers.EnemyController;
using Extentions;
using UnityEngine;

namespace States.PlayerStates
{
    public class EnemyAnimationIdleState : EnemyAnimationBaseState
    {
        public override void EnterState(EnemyAnimationController enemyState)
        {
            enemyState.GetAnimator().SetBool("Walking", false);
            enemyState.GetAnimator().SetBool("Fight", false);
            enemyState.GetAnimator().SetBool("Idle", true);
            enemyState.GetAnimator().SetBool("Dead", false);
        }

        public override void UpdateState(EnemyAnimationController playerState)
        {
            
        }
        
        public override void OnCollisionEnter(EnemyAnimationController playerState)
        {
            
        }
    }
}